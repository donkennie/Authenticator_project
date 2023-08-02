﻿using Authenticator_project.Core;
using Authenticator_project.DTOs;
using Authenticator_project.Models;
using Authenticator_project.Services.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Authenticator_project.Features.Commands
{
    public class LoginUserCommand : IRequest<APIResponse>
    {
        public LoginDTO LoginDTO { get; set; }
    }

    public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, APIResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<APIResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.LoginDTO.UserName);
            if (user is null)
            {
                return APIResponse.GetFailureMessage(HttpStatusCode.BadRequest, null, ResponseMessages.NotFound);
            }

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, request.LoginDTO.Password, false);
            if(!result.Succeeded)
            {
                var failedResponse = APIResponse.GetFailureMessage(HttpStatusCode.BadRequest, null, ResponseMessages.NotFound);
            }

            return APIResponse.GetSuccessMessage(HttpStatusCode.Created, data: _tokenService.CreateToken, ResponseMessages.LoginSuccess);

        }
    }
}
