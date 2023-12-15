using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreWebAPIClass.Domain.Models.Auth
{
    public class SignInModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
