using Microsoft.AspNetCore.Mvc;
using TesteMTP.Data;
using TesteMTP.Models;
using TesteMTP.ViewModel;

namespace TesteMTP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost]
        public IActionResult Add(TaskViewModel taskViewModel)
        {
            var tasks = new Models.Task(taskViewModel.Tasks, taskViewModel.IsCompleted);
            _taskRepository.Add(tasks);

            return Ok($"Tarefa " + $"'{tasks.Tasks}'" + " inserida na lista de tarefas!");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _taskRepository.GetAll();
            return Ok(tasks);
        }

        [HttpDelete("{task}")]
        public IActionResult Delete(string task)
        {
            try
            {
                _taskRepository.Delete(task);
                return Ok("Tarefa excluída com sucesso.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir a tarefa: {ex.Message}");
            }
        }


    }
}
