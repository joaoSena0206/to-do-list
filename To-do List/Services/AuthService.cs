using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using To_do_List.Configurations;
using To_do_List.DataAccess;
using To_do_List.DTOs.User;

namespace To_do_List.Services
{
    public class AuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserDAL _userDAL;

        public AuthService(IOptions<JwtSettings> jwtSettings, UserDAL userDAL)
        {
            _jwtSettings = jwtSettings.Value;
            _userDAL = userDAL;
        }

        public string ValidateUser(LoginUserDTO user)
        {
            string passwordHash = _userDAL.GetPasswordHash(user.Email);

            if (String.IsNullOrEmpty(passwordHash))
            {
                throw new Exception("Usuário não cadastrado!");
            }

            if (BCrypt.Net.BCrypt.Verify(user.Password, passwordHash))
            {
                return GenerateToken(user.Email);
            }

            throw new Exception("Usuário ou senha incorretas!");
        }

        private string GenerateToken(string email)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, email)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken tokenDescriptor = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
