using ASPNetCoreWebAPIClass.Domain.Entities.Auth;
using ASPNetCoreWebAPIClass.Domain.Models.Auth;
using ASPNetCoreWebAPIClass.Domain.Services.Models;
using Microsoft.AspNetCore.Identity;

namespace ASPNetCoreWebAPIClass.Domain.Services
{
    public interface IUserAccountService
    {
        Task<(bool, string)> CreateUser(SignupModel model);
        Task<string> Login(SignInModel model);
    }

    public class UserAccountService : IUserAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailservice;

        public UserAccountService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager, ITokenService tokenService, IEmailService emailservice)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _emailservice = emailservice;
        }

        public async Task<(bool, string)> CreateUser(SignupModel model)
        {
            var user = new User
            {
                Email = model.Email,
                EmailConfirmed = true,
                NormalizedEmail = model.Email.ToUpper(),
                NormalizedUserName = model.Email.ToUpper(),
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            //Create User
            var result = await _userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                _emailservice.SendEmail(new EmailModel
                {
                    body = $"<p>Dear {user.FirstName},</p><p>Welcome to our application. We are glad to have you join us.</p><p>For further enquiries please contact our customer care center.</p>",
                    emailFrom = "seanadeyemi@gmail.com",
                    emailTo = user.Email,
                    name = user.FirstName,
                    subject = "Welcome to ASPNET Core Class app"
                });

                return (true, "User was created successfully");
            }




            return (false, result.Errors.ElementAt(0).Description);

        }

        public async Task<string> Login(SignInModel model)
        {
            User user = null;

            try
            {
                user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    return "invalid User";
                }

                var passwordresult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

                var roles = await _userManager.GetRolesAsync(user);

                if (passwordresult == PasswordVerificationResult.Failed)
                {
                    return "Please input correct login details";
                }

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                //if (!result.Succeeded)
                //{
                //    return "Unable to login";
                //}

                var token = _tokenService.GenerateAccessToken(user, roles.ToList());

                return token;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
