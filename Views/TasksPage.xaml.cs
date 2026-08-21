using ToDoList.ViewModels;

namespace ToDoList.Views;

public partial class TasksPage : ContentPage
{
    private readonly TaskViewModel _viewmodel;

    public TasksPage(TaskViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewmodel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewmodel.LoadTasks();
    }
}