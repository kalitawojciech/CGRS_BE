using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace CGRS.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        #region Queries

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok();
        }

        #endregion
    }
}
