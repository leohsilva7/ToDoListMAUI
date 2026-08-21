using ToDoList.Views;

namespace ToDoList
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("NewTaskPage", typeof(NewTaskPage));
        }
    }
}
