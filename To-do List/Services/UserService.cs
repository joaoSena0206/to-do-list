using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using To_do_List.DataAccess;
using To_do_List.DTOs.User;
using To_do_List.Models;

namespace To_do_List.Services
{
    public class UserService
    {
        public readonly UserDAL _userDAL;

        public UserService(UserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public void RegisterUser(RegisterUserDTO userDTO)
        {
            string password = userDTO.Password;
            List<string> errors = new List<string>();

            // Checa a segurança da senha do usuário para evitar ataques
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

            User user = new User() {
                Email = userDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password)
            };

            _userDAL.AddUser(user);
        }
    }
}
