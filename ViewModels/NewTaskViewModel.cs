using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoList.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.ViewModels;

public partial class NewTaskViewModel : ObservableObject
{
    private readonly ITaskService _taskService;
    [ObservableProperty] private string _nome = string.Empty;

    public NewTaskViewModel(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [RelayCommand]
    private async Task AddTask()
    {
        if (Nome == "")
        {
            return;
        }
        var newTask = new Tarefa
        {
            Name = Nome,
            IsConcluded = false
        };
        _taskService.AddTask(newTask);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private static async Task Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }
}