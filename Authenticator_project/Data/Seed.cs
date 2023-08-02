using Authenticator_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Authenticator_project.Data
{
    public static class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var roles = new List<AppRole>
        {
            new AppRole { Name = "FrontOffice" },
            new AppRole { Name = "BackOffice" },
            new AppRole { Name = "Admin" }
        };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var users = new List<AppUser>
        {
            new AppUser
            {
                FirstName = "Tracy",
                LastName = "Tucker",
                Email = "tracy@gmail.com",
                UserName = "Tracie"
            },
            new AppUser
            {
                FirstName = "Zoey",
                LastName = "Stevens",
                Email = "zoey@gmail.com",
                UserName = "Zoe"
            },
            new AppUser
            {
                FirstName = "Jenny",
                LastName = "Nichols",
                Email = "jennie@gmail.com",
                UserName = "Jennie"
            },

            new AppUser
                {
                    FirstName = "Earl",
                    LastName = "Reed",
                    Email = "earl@gmail.com",
                    UserName = "Kreed",
                },

                new AppUser
                {
                    FirstName = "Sheila",
                    LastName = "Chapman",
                    Email = "chapman@gmail.com",
                    UserName = "Champion",
                },

                new AppUser
                {
                    FirstName = "Ricardo",
                    LastName = "Butler",
                    Email = "butler@gmail.com",
                    UserName = "Richie",
                }
        };

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");

                if (user.UserName == "tracie")
                {
                   await userManager.AddToRoleAsync(user, "FrontOffice");
                   
                }
                else if (user.UserName == "zoe")
                {
                     await userManager.AddToRoleAsync(user, "BackOffice");
                }
                else if (user.UserName == "jennie")
                {
                     await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }

}
