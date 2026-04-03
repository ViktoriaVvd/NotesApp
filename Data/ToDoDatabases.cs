using NoteApp.Models;
using SQLite;

namespace NoteApp.Data
{
    public class ToDoDatabases
    {
        private readonly SQLiteAsyncConnection _connection;

        public ToDoDatabases()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ToDo.db");
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<ToDoItem>().Wait();
        }
        public Task<List<ToDoItem>> GetItems()
        {
            return _connection.Table<ToDoItem>().ToListAsync();
        }

        public Task<int> SaveItem(ToDoItem item)
        {
            if (item.Id == 0)
                return _connection.InsertAsync(item);
            else
                return _connection.UpdateAsync(item);

        }

        public Task<int> DeleteItem(ToDoItem item)
        {
            return _connection.DeleteAsync(item);
        }
    }
}
