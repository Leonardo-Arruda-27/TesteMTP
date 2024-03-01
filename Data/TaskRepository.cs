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

        public void Add(Models.Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void Delete(string task)
        {
            var taskToDelete = _context.Task.FirstOrDefault(x => x.Tasks == task);

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

        public List<Models.Task> GetAll()
        {
            return _context.Task.ToList();
        }
    }
}
