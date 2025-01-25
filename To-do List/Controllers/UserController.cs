using Microsoft.AspNetCore.Mvc;
using To_do_List.DataAccess;
using To_do_List.DTOs.User;
using To_do_List.Models;

namespace To_do_List.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserDAL _userDAL;
        
        public UserController(IConfiguration configuration)
        {
            _userDAL = new UserDAL(configuration.GetConnectionString("DefaultConnection")!);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] RegisterUserDTO userDTO)
        {
            User user = new User();
            user.Email = userDTO.Email;
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

            _userDAL.CreateUser(user);
            
            return Ok("Usuário cadastrado com sucesso!");
        }
    }
}
