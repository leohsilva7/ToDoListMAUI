using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoList.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.ViewModels;

public partial class TaskViewModel : ObservableObject
{
    private readonly ITaskService _taskService;

    [ObservableProperty] private ObservableCollection<Tarefa> _tasks;

    public TaskViewModel(ITaskService taskService)
    {
        _taskService = taskService;
        _tasks = new ObservableCollection<Tarefa>();
    }

    public async Task LoadTasks()
    {
        var tasks = await _taskService.GetTasks();
        Tasks.Clear();
        foreach (var task in tasks) Tasks.Add(task);
    }

    [RelayCommand]
    private async Task NavigateNewTask()
    {
        await Shell.Current.GoToAsync("NewTaskPage");
    }

    [RelayCommand]
    private void RemoveTask(Tarefa task)
    {
        _taskService.DeleteTask(task);
        Tasks.Remove(task);
    }
}