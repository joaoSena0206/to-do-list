using System.ComponentModel.DataAnnotations;

namespace To_do_List.DTOs.User
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória!")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 6 caracteres!")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirme a senha!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não estão iguais!")]
        public string? ConfirmPassword { get; set; }
    }
}
