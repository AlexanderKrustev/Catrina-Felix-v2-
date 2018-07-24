namespace web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using Entities.Account;
    using Entities.DTO;
    using Data;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Security.Claims;
    using Entities;

    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private RoleManager<IdentityRole> roleManager;
        private CatrinaContext context;

        public TokenController(IConfiguration config,
            UserManager<User> userManager,
            CatrinaContext con,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager
                         )
        {
            _config = config;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = con;
            this.roleManager = roleManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var result = await this.signInManager.PasswordSignInAsync(login.Username, login.Password, true, false);

            if (result.Succeeded)
            {
                var user = await this.userManager.FindByEmailAsync(login.Username);
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }
            else
            {
                response = Unauthorized();
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var result = this.userManager.CreateAsync(new User
            {
                Email = login.Username,
                UserName = login.Username
            }, login.Password);


            if (!result.Result.Errors.Any())
            {
                await this.context.SaveChangesAsync();
                var user = await this.userManager.FindByEmailAsync(login.Username);
                await this.userManager.AddToRoleAsync(user, Roles.NormalUser.ToString());
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });


            }
            else
            {
                response = BadRequest(result.Result.Errors);
            }

            return response;
        }

        private string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>();

            var userRoles = this.userManager.GetRolesAsync(user).Result;

            foreach (var role in userRoles)
            {
                claims.Add(new Claim("role", role.ToString()));   //TODO: To add user`s roles to the token dynamicly 
            }

            claims.Add(new Claim("username", user.UserName));
            

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
