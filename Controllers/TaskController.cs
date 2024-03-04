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

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _taskRepository.GetAll();
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Add(TaskViewModel taskViewModel)
        {
            var tasks = new Models.Task(taskViewModel.Tasks, taskViewModel.IsCompleted);
            _taskRepository.Add(tasks);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var taskToDelete = _taskRepository.GetTaskById(id);

            if (taskToDelete == null)
            {
                return NotFound("Tarefa não encontrada.");
            }

            _taskRepository.Delete(taskToDelete);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutTask(int id)
        {
            var task = _taskRepository.GetTaskById(id);

            if (task == null)
            {
                return NotFound("Tarefa não encontrada.");
            }

            _taskRepository.PutTask(task);
            return Ok();
        }

    }
}
