using Microsoft.Extensions.Logging;
using ToDoList.Services;
using ToDoList.Services.Interfaces;
using ToDoList.ViewModels;
using ToDoList.Views;

namespace ToDoList;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<ITaskService, TaskServiceSqlite>();
        builder.Services.AddTransient<TaskViewModel>();
        builder.Services.AddTransient<TasksPage>();
        builder.Services.AddTransient<NewTaskViewModel>();
        builder.Services.AddTransient<NewTaskPage>();
        return builder.Build();
    }
}