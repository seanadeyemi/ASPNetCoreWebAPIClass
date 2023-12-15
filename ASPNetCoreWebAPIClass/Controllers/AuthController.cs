using ASPNetCoreWebAPIClass.Domain.Models.Auth;
using ASPNetCoreWebAPIClass.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreWebAPIClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        public AuthController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] SignInModel signInModel)
        {
            try
            {
                var token = await _userAccountService.Login(signInModel);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized();
                }

                return Ok(token);

            }
            catch (Exception ex)
            {
                return BadRequest(new { });
            }
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] SignupModel signupModel)
        {
            try
            {
                var (success, responseMessage) = await _userAccountService.CreateUser(signupModel);

                return Ok(new { result = responseMessage });

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
