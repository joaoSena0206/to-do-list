using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace To_do_List.Validations
{
    public class PasswordStrength : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string password = value!.ToString()!;

            if (password.Length < 8)
            {
                return new ValidationResult("A senha deve ter pelo menos 8 caracteres!");
            }

            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                return new ValidationResult("A senha deve conter pelo menos uma letra maiúscula!");
            }

            if (!Regex.IsMatch(password, "[a-z]"))
            {
                return new ValidationResult("A senha deve conter pelo menos uma letra minúscula!");
            }

            if (!Regex.IsMatch(password, "[0-9]"))
            {
                return new ValidationResult("A senha deve conter pelo menos um número!");
            }

            if (!Regex.IsMatch(password, "[!@#$&*]"))
            {
                return new ValidationResult("A senha deve conter pelo menos um caractere especial!");
            }

            return ValidationResult.Success;
        }
    }
}
