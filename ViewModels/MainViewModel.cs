
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Data;
using NoteApp.Models;

namespace NoteApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly NotesDatabases _database;

        [ObservableProperty]
        private ObservableCollection<NoteItem> noteItems;

        [ObservableProperty]
        private string newNoteTitle;

        [ObservableProperty]
        private string newNoteContent;

        public MainViewModel()
        {
            _database = new NotesDatabases();
            LoadItems();
        }


        [RelayCommand]
        private async void LoadItems()
        {
            var items = await _database.GetItems();
            NoteItems = new ObservableCollection<NoteItem>(items);
        }

        [RelayCommand]

        private async void GoToNotes() {
            await Shell.Current.GoToAsync("//NotesPage");
        }

        [RelayCommand]
        private async void GoToTasks() {
            
        }

        [RelayCommand]
        public async Task AddItem()
        {
            //await Shell.Current.DisplayAlertAsync("Назва нотатки", "Вміст нотатки", "закрити");
            if (!string.IsNullOrEmpty(NewNoteTitle) || !string.IsNullOrEmpty(NewNoteContent))
            {
                var newItem = new NoteItem { Title = NewNoteTitle, Content = NewNoteContent };
                await _database.SaveItem(newItem);
                NewNoteTitle = "";
                NewNoteContent = "";
                LoadItems();
            }
        }
    }
}
