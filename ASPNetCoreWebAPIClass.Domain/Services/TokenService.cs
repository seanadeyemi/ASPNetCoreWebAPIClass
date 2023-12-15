using ASPNetCoreWebAPIClass.Domain.Entities.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASPNetCoreWebAPIClass.Domain.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user, List<string> roles);
    }

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(User user, List<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Authentication:JwtBearer:SecretKey").Value);
            var minutes = Convert.ToDouble(_configuration.GetSection("Authentication:JwtBearer:AccessExpiration").Value);

            var claims = new List<Claim>
                {
                 new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? "0800000000"),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim("firstName", user.FirstName),
                 new Claim("lastName", user.LastName),
                 new Claim(ClaimTypes.Country, "Nigeria")
                };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = _configuration.GetSection("Authentication:JwtBearer:Audience").Value,
                Issuer = _configuration.GetSection("Authentication:JwtBearer:Issuer").Value,
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
