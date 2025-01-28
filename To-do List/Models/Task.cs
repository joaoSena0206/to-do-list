namespace To_do_List.Models
{
    public class Task
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Task() 
        {
            User = new User();
            Title = string.Empty;
            Description = string.Empty;
        }
    }
}
