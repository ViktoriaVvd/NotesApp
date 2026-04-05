using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Data;
using NoteApp.Models;

namespace NoteApp.ViewModels
{
    public partial class NotesViewModel : ObservableObject
    {
        private readonly NotesDatabases _database;

        [ObservableProperty]
        private ObservableCollection<NoteItem> noteItems;

        [ObservableProperty] 
        private string newNoteTitle;

        [ObservableProperty]
        private string newNoteContent;


        public NotesViewModel()
        {
            _database = new NotesDatabases();
            LoadItems();
        }


        [RelayCommand]
        private async Task LoadItems()
        {
            var items = await _database.GetItems();
            NoteItems = new ObservableCollection<NoteItem>(items);
        }

        [RelayCommand]
        private async Task AddItem()
        {
            if (!string.IsNullOrEmpty(NewNoteTitle) || !string.IsNullOrEmpty(NewNoteContent))
            {
                var newItem = new NoteItem { Title = NewNoteTitle, Content = NewNoteContent };
                await _database.SaveItem(newItem);
                NewNoteTitle = "";
                NewNoteContent = "";
                LoadItems();
            }
        }

        [RelayCommand]
        private async Task DeleteItem(NoteItem item)
        {
            await _database.DeleteItem(item);
            LoadItems();
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
