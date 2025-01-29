using To_do_List.DataAccess;
using To_do_List.DTOs.Task;
using To_do_List.Models;

namespace To_do_List.Services
{
    public class TaskService
    {
        private readonly TaskDAL _taskDAL;

        public TaskService(TaskDAL taskDAL)
        {
            _taskDAL = taskDAL;
        }

        public void CreateTask(CreateTaskDTO taskDTO, string email)
        {
            Models.Task task = new Models.Task
            {
                User = new User { Email = email },
                Title = taskDTO.Title,
                Description = taskDTO.Description,
                DueDate = taskDTO.DueDate,
                IsCompleted = false
            };

            _taskDAL.AddTask(task);
        }

        public List<ShowTaskDTO> GetTasks(string email)
        {
            return _taskDAL.GetTasks(email);
        }

        public void CompleteTask(int taskId, string email)
        {
            if (_taskDAL.CheckTaskExistence(taskId, email))
            {
                _taskDAL.CompleteTask(taskId);
            }
            else
            {
                throw new Exception("Tarefa não encontrada!");
            }
        }
    }
}
