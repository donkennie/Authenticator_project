using Authenticator_project.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {

        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();

        protected ActionResult HandleResult(APIResponse result)
        {
            if (result is null)
            {
                return NotFound();
            }

            if (result.IsSuccess && result.Data != null)
            {
                return Ok(result.Data);
            }

            if (result.IsSuccess && result.Data is null)
            {
                return NotFound();
            }

            return BadRequest(result.Message);
        }

    }
}
