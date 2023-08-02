using Microsoft.AspNetCore.Identity;

namespace Authenticator_project.Models
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
