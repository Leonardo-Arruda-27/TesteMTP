﻿
namespace TesteMTP.Models
{
    public class Task
    {
        public int Id { get; private set; }
        public string Tasks { get; private set; }
        public bool IsCompleted { get; set; }

        public Task(string tasks, bool isCompleted)
        {
            Tasks = tasks;
            IsCompleted = isCompleted;
        }
    }
}
