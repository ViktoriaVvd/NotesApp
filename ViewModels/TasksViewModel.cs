using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Models;
using NoteApp.Service;

namespace NoteApp.ViewModels
{

    public partial class TasksViewModel : ObservableObject
    {
        private readonly TasksService _service = new TasksService();
        public ObservableCollection<TaskItem> Tasks { get; } = new();

        [ObservableProperty]
        private bool _isButtonVisible = true;

        [ObservableProperty]
        private bool _isRefreshing;

        [RelayCommand]
        public async Task LoadTasks()
        {
            IsRefreshing = true;
            try
            {
                var items = await _service.GetTodosAsync();

                if (items != null && items.Count > 0)
                {
                    Tasks.Clear();
                    foreach (var item in items)
                    {
                        Tasks.Add(item);
                    }

                    IsButtonVisible = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Помилка: {ex.Message}");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        private async Task DeleteTask(TaskItem task)
        {
            if (task == null) return;
            await _service.DeleteTaskAsync(task);
        }


        [RelayCommand]
        private async Task ToDb()
        {
            var items = await _service.ShowDbContent();

            string content = items.Any()
            ? " ~ " + string.Join("\n ~ ", items.Select(i => i.Title))
            : "База даних порожня";
            await Shell.Current.DisplayAlertAsync("Елементи в БД", content, "OK");
        }
        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
} 