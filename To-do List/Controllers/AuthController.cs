using Microsoft.AspNetCore.Mvc;
using To_do_List.DTOs.User;
using To_do_List.Services;

namespace To_do_List.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult SignInUser(LoginUserDTO user)
        {
            try
            {
                string token = _authService.ValidateUser(user);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
