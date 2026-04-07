using NoteApp.Models;
using SQLite;

namespace NoteApp.Data
{
    public class TasksDatabases
    {
        private SQLiteAsyncConnection _connection;

        public async Task Init()
        {
            if (_connection != null) return;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Tasks.db");
            _connection = new SQLiteAsyncConnection(dbPath);
            await _connection.CreateTableAsync<TaskItem>();
        }
        public async Task<List<TaskItem>> GetItems()
        {
            await Init();
            return await _connection.Table<TaskItem>().ToListAsync();
        }

        public async Task<int> SaveItem(TaskItem item)
        {
            await Init();
            if (item.Id == 0)
                return await _connection.InsertAsync(item);
            else
                return await _connection.UpdateAsync(item);

        }

        public async Task SaveAllItems(List<TaskItem> items)
        {
            await Init();
            await _connection.InsertAllAsync(items);
        }


        public async Task<int> DeleteItem(TaskItem item)
        {
            await Init();
            return await _connection.DeleteAsync(item);
        }

        public async Task<int> DeleteItemById(int id)
        {
            await Init();
            return await _connection.DeleteAsync<TaskItem>(id);
        }

        public async Task<int> ClearDB()
        {
            await Init();
            return await _connection.DeleteAllAsync<TaskItem>();
        }
    }
}
