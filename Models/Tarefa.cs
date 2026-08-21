using SQLite;
namespace ToDoList.Models;

public class Tarefa
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsConcluded { get; set; }
}