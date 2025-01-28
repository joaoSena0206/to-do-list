using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using To_do_List.Configurations;
using To_do_List.DataAccess;
using To_do_List.DTOs.User;
using To_do_List.Models;

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

        public void RegisterUser(RegisterUserDTO userDTO)
        {
            string password = userDTO.Password;
            List<string> errors = new List<string>();

            #region Checa a segurança da senha do usuário para evitar ataques

            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                errors.Add("A senha deve conter pelo menos uma letra maiúscula!");
            }

            if (!Regex.IsMatch(password, "[a-z]"))
            {
                errors.Add("A senha deve conter pelo menos uma letra minúscula!");
            }

            if (!Regex.IsMatch(password, "[0-9]"))
            {
                errors.Add("A senha deve conter pelo menos um número!");
            }

            if (!Regex.IsMatch(password, "[!@#$&*]"))
            {
                errors.Add("A senha deve conter pelo menos um caractere especial!");
            }

            if (errors.Count > 0)
            {
                throw new Exception(JsonConvert.SerializeObject(errors, Formatting.Indented));
            }

            #endregion

            User user = new User()
            {
                Email = userDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password)
            };

            _userDAL.AddUser(user);
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
            Dictionary<string, object> claims = new Dictionary<string, object>
            {
                [ClaimTypes.Name] = email
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Claims = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = creds
            };

            return new JsonWebTokenHandler().CreateToken(tokenDescriptor);
        }
    }
}
