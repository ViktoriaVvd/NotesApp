using NoteApp.Pages;
using NoteApp.ViewModels;

namespace NoteApp.Pages;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}
