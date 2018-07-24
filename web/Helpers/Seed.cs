namespace web
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Entities.Account;
    using Entities;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Builder;

    public static class Seed
    {
       
        public static void InitializeRolesAsync(IApplicationBuilder app)
        {

            var scope = CreateScope(app);
           
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (roleManager.Roles.Any())
            {
                return;
            }

            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }

                       
        }

        public static void CreateAdmin(IApplicationBuilder app)
        {
            var scope = CreateScope(app);

            
             var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
             var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var isadminUserExists = userManager.FindByNameAsync("admin").Result != null;
            var isAdminHasRights = userManager.IsInRoleAsync(userManager.FindByNameAsync("admin").Result, Roles.Administrator.ToString()).Result;

            if (isadminUserExists && isAdminHasRights)
             {
                 return;
             }
             else if(!isAdminHasRights && isadminUserExists)
             {
                var user = userManager.FindByNameAsync("admin").Result;
                userManager.AddToRoleAsync(userManager.FindByNameAsync("admin").Result, "Administrator");

             }
            else
            {
                var user = new User()
                {
                    UserName = "admin",
                    Email = "admin@admin.com"
                };

                var result = userManager.CreateAsync(user, "alex0101A!@#");

                userManager.AddToRoleAsync(userManager.FindByNameAsync("admin").Result, "Administrator");
            }
        }


        private static IServiceScope CreateScope(IApplicationBuilder app)
        {
            return app.ApplicationServices.CreateScope();
        }

    }
}
