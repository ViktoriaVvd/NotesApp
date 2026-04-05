using NoteApp.Models;
using SQLite;

namespace NoteApp.Data
{
    public class TasksDatabases
    {
        private readonly SQLiteAsyncConnection _connection;

        public TasksDatabases()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ToDo.db");
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<TaskItem>().Wait();
        }
        public Task<List<TaskItem>> GetItems()
        {
            return _connection.Table<TaskItem>().ToListAsync();
        }

        public Task<int> SaveItem(TaskItem item)
        {
            if (item.Id == 0)
                return _connection.InsertAsync(item);
            else
                return _connection.UpdateAsync(item);

        }

        public Task<int> DeleteItem(TaskItem item)
        {
            return _connection.DeleteAsync(item);
        }
    }
}
