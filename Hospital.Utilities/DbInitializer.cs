using Hospital.Models;
using Hospital.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Utilities
{
    public class DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext) : IDbInitializer
    {
        public void Initialize()
        {
            try
            {
                if (dbContext.Database.GetPendingMigrations().Any())
                    dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while initializing the database.", ex);
            }

            if (!roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Sorin",
                    Email = "abcdef@yahoo.com"
                }, "Sorin@123").GetAwaiter().GetResult();

                var appUser = dbContext.ApplicationUsers.FirstOrDefault(x => x.Email == "abcdef@yahoo.com");

                if (appUser != null)
                    userManager.AddToRoleAsync(appUser, WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();
            }

            if (!roleManager.RoleExistsAsync(WebSiteRoles.Website_Patient).GetAwaiter().GetResult())
                roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Website_Patient)).GetAwaiter().GetResult();

            if (!roleManager.RoleExistsAsync(WebSiteRoles.Website_Doctor).GetAwaiter().GetResult())
                roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Website_Doctor)).GetAwaiter().GetResult();
        }
    }
}