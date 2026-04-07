using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using NoteApp.Data;
using NoteApp.Models;
using SQLite;

namespace NoteApp.Service
{
    public class TasksService
    {
        private TasksDatabases _db;
        private readonly HttpClient _httpClient = new();

        public TasksService()
        {
            if (_db != null) return;
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Tasks.db3");
            _db = new TasksDatabases(); ;
            //await _db.CreateTableAsync<TaskItem>();
        }

        public async Task<List<TaskItem>> GetTodosAsync()
        {
            try
            {
                var url = "https://jsonplaceholder.typicode.com/todos?completed=false&_limit=20";
                var items = await _httpClient.GetFromJsonAsync<List<TaskItem>>(url);

                if (items != null)
                {
                    await _db.ClearDB();
                    await _db.SaveAllItems(items);
                    return items;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Помилка API: {ex.Message}");
            }
            return await _db.GetItems();
        }

        public async Task<List<TaskItem>> ShowDbContent()
        {
            return await _db.GetItems();
        }

        public async Task<int> DeleteTaskAsync(TaskItem task)
        {
            return await _db.DeleteItem(task);
        }


    }
}
