using System.ComponentModel.DataAnnotations;

namespace To_do_List.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public Task() 
        {
            User = new User();
            Title = string.Empty;
            Description = string.Empty;
        }
    }
}
