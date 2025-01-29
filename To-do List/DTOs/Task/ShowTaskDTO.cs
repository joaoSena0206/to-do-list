namespace To_do_List.DTOs.Task
{
    public class ShowTaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public ShowTaskDTO()
        { 
            Title = string.Empty;
            Description = string.Empty;
            DueDate = string.Empty;
        }
    }
}
