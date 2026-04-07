using System.Windows.Input;
using NoteApp.Models;

namespace NoteApp.Controls;

public partial class TaskItemControl : ContentView
{
    public static readonly BindableProperty TaskProperty =
        BindableProperty.Create(nameof(Task), typeof(TaskItem), typeof(TaskItemControl), null);

    public TaskItem Task
    {
        get => (TaskItem)GetValue(TaskProperty);
        set => SetValue(TaskProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty =
        BindableProperty.Create(nameof(DeleteCommand), typeof(ICommand), typeof(TaskItemControl), null);

    public ICommand DeleteCommand
    {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value && DeleteCommand != null && DeleteCommand.CanExecute(Task))
        {
            DeleteCommand.Execute(Task);
        }
    }

    public TaskItemControl()
    {
        InitializeComponent();
    }
}