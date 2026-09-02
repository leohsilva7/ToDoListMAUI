using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.ViewModels
{
    [QueryProperty(nameof(Tarefa), "TarefaObj")]
    public partial class EditTaskViewModel : ObservableObject
    {
        [ObservableProperty]
        private Tarefa task;
        private readonly ITaskService _taskService;
        [ObservableProperty]
        private string taskName;
        public EditTaskViewModel(ITaskService taskService)
        {
            _taskService = taskService;
        }
        partial void OnTaskChanged(Tarefa value)
        {
            if (value == null)
            {
                TaskName = value.Name;
            }
        }
        [RelayCommand]
        private async Task Save()
        {
            Task.Name = TaskName;
            await _taskService.UpdateTask(Task);
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        private async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
