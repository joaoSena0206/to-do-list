using System.ComponentModel.DataAnnotations;

namespace To_do_List.DTOs.Task
{
    public class CreateTaskDTO
    {
        [Required(ErrorMessage = "O título da tarefa é obrigatório!")]
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
