using ToDoList.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services;

public class TaskService : ITaskService
{
    // Lista de Tasks na Memória
    private readonly List<Tarefa> _tasks = new();

    public ICollection<Tarefa> GetTasks()
    {
        return _tasks.ToList().AsReadOnly();
    }

    public void AddTask(Tarefa task)
    {
        _tasks.Add(task);
    }

    public void DeleteTask(Tarefa task)
    {
        var currentTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
        if (currentTask != null) _tasks.Remove(currentTask);
    }

    Task<ICollection<Tarefa>> ITaskService.GetTasks()
    {
        throw new NotImplementedException();
    }

    Task ITaskService.AddTask(Tarefa task)
    {
        throw new NotImplementedException();
    }

    Task ITaskService.DeleteTask(Tarefa task)
    {
        throw new NotImplementedException();
    }
}