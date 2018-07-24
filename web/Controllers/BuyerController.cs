namespace web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Data;
    using Entities.Deals;
    using Entities.DTO;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using web.Helpers;

    [Produces("application/json")]
    [Route("api/Buyer")]
    public class BuyerController : Controller
   {
        private CatrinaContext db;

        public BuyerController(CatrinaContext context)
        {
            this.db = context;
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] BuyerCreateModel buyerModel)
        {

            var username = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "username").Value.ToString();
            var user = this.db.Users.FirstOrDefault(c => c.UserName == username);
            Loger.Log(this.ControllerContext, user, this.db);    
            
            if (ModelState.IsValid)
            {
                var buyer = new Buyer()
                {
                    Name = buyerModel.Name
                };

                if (this.db.Buyers.Any(n => n.Name == buyer.Name))
                {
                     return NotFound($"Buyer with {buyer.Name} already exists!!!");  //TODO: Adjust the status codes
                 
                }

                await this.db.Buyers.AddAsync(buyer);
                await this.db.SaveChangesAsync();

                return  Ok(buyer);
            }

            return BadRequest();
        }
    }
}