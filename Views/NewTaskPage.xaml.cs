using ToDoList.ViewModels;

namespace ToDoList.Views;

public partial class NewTaskPage : ContentPage
{
    // private readonly NewTaskViewModel _viewModel;

    public NewTaskPage(NewTaskViewModel newTaskViewModel)
    {
        InitializeComponent();
        BindingContext = newTaskViewModel;
        // _viewModel = newTaskViewModel;
    }
}