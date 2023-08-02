using Authenticator_project.DTOs;
using Authenticator_project.Models;

namespace Authenticator_project.Services.Abstractions
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);

        Task<UserDTO> CreateUserObject(AppUser user);
    }
}
