namespace TesteMTP.Models
{
    public interface ITaskRepository
    {
        void Add(Task task);
        List<Models.Task> GetAll();
        void Delete(string task);
    }
}
