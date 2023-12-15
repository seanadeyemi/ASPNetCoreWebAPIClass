using ASPNetCoreWebAPIClass.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreWebAPIClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private ReqResService _resService;
        public UserController(IUserService userService, ReqResService resService)
        {
            _userService = userService;
            _resService = resService;
        }
        [HttpGet]
        [Route("get-user-by-id")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            var user = await _userService.GetUser(id);

            return Ok(user);


        }

        [HttpGet]
        [Route("get-users-page")]
        public async Task<IActionResult> GetUsersPage(int page, int itemsPerPage)
        {
            var users = await _resService.GetUsers(page, itemsPerPage);

            return Ok(users);
        }


    }
}
