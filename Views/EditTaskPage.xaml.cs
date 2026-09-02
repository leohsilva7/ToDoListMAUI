using ToDoList.ViewModels;

namespace ToDoList.Views;

public partial class EditTaskPage : ContentPage
{
	private readonly EditTaskViewModel _viewModel;
	public EditTaskPage(EditTaskViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
	}
}