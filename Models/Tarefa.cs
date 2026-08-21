namespace ToDoList.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsConcluded { get; set; }
}