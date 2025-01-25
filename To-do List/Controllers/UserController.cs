using Microsoft.AspNetCore.Mvc;
using To_do_List.DTOs.User;
using To_do_List.Services;

namespace To_do_List.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] RegisterUserDTO userDTO)
        {
            try
            {
                _userService.RegisterUser(userDTO);

                return Ok("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
