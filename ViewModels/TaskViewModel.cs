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
    private async Task NavigateEditTask(Tarefa task)
    {
        if (task == null)
        {
            return;
        }
        var navigationParameter = new Dictionary<string, object>
        {
            { "TarefaObj", task }
        };
        await Shell.Current.GoToAsync("EditTaskPage", navigationParameter);
    }
    [RelayCommand]
    private async Task NavigateNewTask()
    {
        await Shell.Current.GoToAsync("NewTaskPage");
    }

    [RelayCommand]
    private async Task RemoveTask(Tarefa task)
    {
        bool confirma = await Shell.Current.DisplayAlert("Excluir Tarefa", "Deseja realmente remover a tarefa", "Sim", "Não");
        if (confirma)
        {
            await _taskService.DeleteTask(task);
            Tasks.Remove(task);
        }
    }
}