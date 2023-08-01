using System.Threading.Tasks;
using CGRS.Application.Dtos;
using CGRS.Application.Dtos.Users;
using CGRS.Application.Users.Commands;
using CGRS.Application.Users.Commands.ChangePassword;
using CGRS.Application.Users.Queries;
using CGRS.Application.Users.Queries.GetCurrentUserData;
using CGRS.Commons.Enumerables;
using CGRS.Domain.Filters;
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
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        [ProducesResponseType(typeof(PagedResponse<UserFullInfoResponse>), 200)]
        public async Task<IActionResult> GetFiltered([FromQuery] UsersFilter usersFilter)
        {
            var response = await _mediator.Send(new GetFilteredUsersQuery(usersFilter));

            return Ok(response);
        }

        [HttpGet("my-data")]
        [ProducesResponseType(typeof(UserProfileResponse), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetFiltered()
        {
            var response = await _mediator.Send(new GetCurrentUserDataQuery(User));

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

        [HttpPut("change-password")]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var response = await _mediator.Send(new ChangePasswordCommand(request, User));
            return Ok(response);
        }
    }
}
