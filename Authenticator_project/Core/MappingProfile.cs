using Authenticator_project.DTOs;
using Authenticator_project.Features.Commands;
using AutoMapper;

namespace Authenticator_project.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginUserRequest, LoginUserCommand>().ReverseMap();
        }
    }
}
