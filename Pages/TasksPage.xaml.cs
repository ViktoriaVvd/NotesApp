using NoteApp.Services;
using NoteApp.ViewModels;

namespace NoteApp.Pages;

public partial class TasksPage : ContentPage
{
	public TasksPage()
	{
		InitializeComponent();
        BindingContext = new TasksViewModel();
    }
}