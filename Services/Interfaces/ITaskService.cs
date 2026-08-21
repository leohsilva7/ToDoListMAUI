using ToDoList.Models;

namespace ToDoList.Services.Interfaces;

public interface ITaskService
{
    ICollection<Tarefa> GetTasks();
    void AddTask(Tarefa task);
    void DeleteTask(Tarefa task);
}