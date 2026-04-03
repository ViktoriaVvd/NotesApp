using System;
using System.Collections.Generic;
using System.Text;
using NoteApp.Models;
using SQLite;

namespace NoteApp.Data
{
    public class NotesDatabases
    {
        private readonly SQLiteAsyncConnection _connection;

        public NotesDatabases()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Notes.db");
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<NoteItem>().Wait();
        }
        public Task<List<NoteItem>> GetItems()
        {
            return _connection.Table<NoteItem>().ToListAsync();
        }

        public Task<int> SaveItem(NoteItem item)
        {
            if (item.Id == 0)
                return _connection.InsertAsync(item);
            else
                return _connection.UpdateAsync(item);

        }

        public Task<int> DeleteItem(NoteItem item)
        {
            return _connection.DeleteAsync(item);
        }
    }
}
