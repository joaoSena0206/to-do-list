using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace To_do_List.Models
{
    public class User
    {
        [Key]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
