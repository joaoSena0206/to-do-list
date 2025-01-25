using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace To_do_List.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Task> Tasks { get; set; }

        public User()
        {
            Email = string.Empty;
            Password = string.Empty;
            Tasks = new List<Task>();
        }
    }
}
