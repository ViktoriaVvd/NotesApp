using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using NoteApp.Models;

namespace NoteApp.Services
{
    public class ApiService
    {
        HttpClient _client = new HttpClient();
        public async Task<List<Task>> GetPostsAsync()
        {
            return await _client.GetFromJsonAsync<List<Task>>("https://example.com");
        }
    }

}
