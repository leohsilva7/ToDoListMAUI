using ToDoList.Models;

namespace ToDoList.Services.Interfaces;

public interface ITaskService
{
    Task<ICollection<Tarefa>> GetTasks();
    Task AddTask(Tarefa task);
    Task DeleteTask(Tarefa task);
}