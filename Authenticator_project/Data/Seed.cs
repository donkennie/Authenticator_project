using Authenticator_project.Models;
using Microsoft.AspNetCore.Identity;

namespace Authenticator_project.Data
{
    public static class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var roles = new List<AppRole>
            {
                new AppRole { Name = "Member" },
                new AppRole { Name = "Admin" },
                new AppRole { Name = "Moderator" }
            };

            // Create roles
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
                    UserName = "Tracie",
                },

                new AppUser
                {
                    FirstName = "Zoey",
                    LastName = "Stevens",
                    Email = "zoey@gmail.com",
                    UserName = "Zoe",
                },

                new AppUser
                {
                    FirstName = "Jenny",
                    LastName = "Nichols",
                    Email = "jennie@gmail.com",
                    UserName = "Jennie",
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

                if (user.UserName == "Tracie")
                {
                    await userManager.AddToRoleAsync(user, "FrontOffice");
                }
                else if (user.UserName == "Zoe")
                {
                    await userManager.AddToRoleAsync(user, "BackOffice");
                }
                else if (user.UserName == "Jennie")
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }

    }
}
