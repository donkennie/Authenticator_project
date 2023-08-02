using Authenticator_project.Core;
using Authenticator_project.DTOs;
using Authenticator_project.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator_project.Controllers
{
    public class AccountController : BaseAPIController
    {
        public readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost()]
        public async Task<ActionResult<APIResponse>> LoginUser(LoginDTO request)
        {
            //var result = await _mediator.Send(request);
            //return Ok(result);
            return HandleResult(await Mediator.Send(new LoginUserCommand {  LoginDTO = request }));
        }
    }
}
