using NoteApp.Pages;
using NoteApp.ViewModels;

namespace NoteApp.Pages;

public partial class NotesPage : ContentPage
{

    public NotesPage()
    {
        InitializeComponent();
        BindingContext = new NotesViewModel();
    }
}