using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Models;
using NoteApp.Services;

namespace NoteApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Text.Json;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;

    public partial class TasksViewModel : ObservableObject
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly JsonSerializerOptions _serializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ObservableCollection<TaskItem> Tasks { get; } = new();


        [RelayCommand]
        private async Task LoadData()
        {
            try
            {
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet) return;

                var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var todoItem = JsonSerializer.Deserialize<TaskItem>(json, _serializerOptions);

                    if (todoItem != null)
                    {
                        Tasks.Add(todoItem);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
