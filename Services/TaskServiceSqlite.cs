using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services
{
    public class TaskServiceSqlite : ITaskService
    {   
        private SQLiteAsyncConnection _connection;
        private async Task ConfigDB()
        {
            if (_connection != null)
            {
                return;
            }
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ToDoList.db3");
            _connection = new SQLiteAsyncConnection(dbPath);
            await _connection.CreateTableAsync<Tarefa>();
        }
        public async Task<ICollection<Tarefa>> GetTasks()
        {
            await ConfigDB();
            return await _connection.Table<Tarefa>().ToListAsync();
        }

        public async Task AddTask(Tarefa task)
        {
            await ConfigDB();
            await _connection.InsertAsync(task);
        }

        public async Task DeleteTask(Tarefa task)
        {
            await ConfigDB();
            await _connection.DeleteAsync(task);
        }

        public async Task UpdateTask(Tarefa task)
        {
            await ConfigDB();
            await _connection.UpdateAsync(task);
        }
    }
}
