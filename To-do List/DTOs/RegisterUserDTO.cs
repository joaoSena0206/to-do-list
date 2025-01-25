using System.ComponentModel.DataAnnotations;

namespace To_do_List.DTOs
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
