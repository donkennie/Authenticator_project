using Authenticator_project.Core;
using Authenticator_project.DTOs;
using Authenticator_project.Features.Commands;
using Authenticator_project.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        public AccountController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> LoginUser(LoginUserRequest request)
        {
            var loginUserCommand = _mapper.Map<LoginUserCommand>(request);
            var result = await _mediator.Send(loginUserCommand);
            return Ok(result);
        }

    }
}
