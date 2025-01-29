using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using To_do_List.DTOs.Task;
using To_do_List.Services;

namespace To_do_List.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateTask(CreateTaskDTO taskDTO)
        {
            try
            {
                _taskService.CreateTask(taskDTO, User.FindFirstValue(ClaimTypes.Name)!);

                return Ok("Tarefa criada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetTasks()
        {
            try
            {
                List<ShowTaskDTO> tasks = _taskService.GetTasks(User.FindFirstValue(ClaimTypes.Name)!);

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Authorize]
        public IActionResult CompleteTask(int taskId)
        {
            try
            {
                _taskService.CompleteTask(taskId, User.FindFirstValue(ClaimTypes.Name)!);

                return Ok("Tarefa completada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
