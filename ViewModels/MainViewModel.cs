
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Data;
using NoteApp.Models;

namespace NoteApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private DateTime currentDateTime = DateTime.Now;

        [RelayCommand]

        private async Task GoToNotes() {
            await Shell.Current.GoToAsync("//NotesPage");
        }

        [RelayCommand]
        private async Task GoToTasks() {
            await Shell.Current.GoToAsync("//TasksPage");
        }

        [RelayCommand]
        private async Task GoToInfo()
        {
            await Shell.Current.GoToAsync("//InfoPage");
        }


    }
}
