using Authenticator_project.Core;
using Authenticator_project.DTOs;
using Authenticator_project.Features.Commands;
using Authenticator_project.Features.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminAndBackOffice")]
    public class AccessController : ControllerBase
    {
        public readonly IMediator _mediator;
        public AccessController(IMediator mediator) => _mediator = mediator;


        [HttpGet("GetFruits")]
        public async Task<ActionResult<APIResponse>> GetFruits()
        {
            return Ok(await _mediator.Send(new GetFruitsQuery.Query()));          
        }


    }
}
