namespace TesteMTP.Models
{
    public interface ITaskRepository
    {
        List<Task> GetAll();
        void Add(Task task);
        void Delete(Task task);
        void PutTask(Task task);
        Task GetTaskById(int task);
    }
}