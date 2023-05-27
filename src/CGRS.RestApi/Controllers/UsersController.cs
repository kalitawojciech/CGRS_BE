using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Application.Dtos.Users;
using CGRS.Application.Users.Commands;
using CGRS.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CGRS.RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserInfoResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());

            return Ok(response);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            await _mediator.Send(new RegisterUserCommand(request));
            return Ok();
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoggedInUserResponse), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationRequest request)
        {
            var response = await _mediator.Send(new AuthenticateUserCommand(request));
            return Ok(response);
        }
    }
}
