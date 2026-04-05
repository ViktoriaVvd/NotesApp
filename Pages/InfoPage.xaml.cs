using NoteApp.ViewModels;

namespace NoteApp.Pages;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
        BindingContext = new InfoViewModel();
    }
}