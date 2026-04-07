using NoteApp.ViewModels;

namespace NoteApp.Pages;

public partial class TasksPage : ContentPage
{
    private TasksViewModel ViewModel { get; set; } = new TasksViewModel();

    public TasksPage()
    {
        InitializeComponent();
        BindingContext = ViewModel;
    }

}
