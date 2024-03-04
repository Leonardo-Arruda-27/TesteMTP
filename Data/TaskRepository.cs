using TesteMTP.Models;

namespace TesteMTP.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ConnectionContext _context;

        public TaskRepository(ConnectionContext context)
        {
            _context = context;
        }

        public List<Models.Task> GetAll()
        {
            return _context.Task.ToList();
        }

        public Models.Task GetTaskById(int taskId)
        {
            var findTask = _context.Task.FirstOrDefault(t => t.Id == taskId);
            return findTask;
        }

        public void Add(Models.Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void Delete(Models.Task task)
        {
            var taskToDelete = _context.Task.FirstOrDefault(t => t.Id == task.Id);

            if (taskToDelete != null)
            {
                _context.Task.Remove(taskToDelete);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Tarefa não encontrada.");
            }
        }

        public void PutTask(Models.Task task)
        {
            var tasks = _context.Task.FirstOrDefault(t => t.Tasks == task.Tasks);

            if (task != null)
            {
                if (tasks.IsCompleted == true)
                {
                    task.IsCompleted = false;
                    _context.SaveChanges();
                }
                else
                {
                    task.IsCompleted = true;
                    _context.SaveChanges();
                }
            }
        }
    }
}
