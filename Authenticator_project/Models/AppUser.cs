using Microsoft.AspNetCore.Identity;

namespace Authenticator_project.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
