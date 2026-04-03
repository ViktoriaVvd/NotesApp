using System.Windows.Input;
using NoteApp.Models;

namespace NoteApp.Controls;

public partial class NoteItemControl : ContentView
{
    public static readonly BindableProperty NoteTitleProperty =
        BindableProperty.Create(nameof(NoteTitle), typeof(string), typeof(NoteItemControl), default(string));

    public static readonly BindableProperty NoteContentProperty =
        BindableProperty.Create(nameof(NoteContent), typeof(string), typeof(NoteItemControl), default(string));
    public string NoteTitle
    {
        get => (string)GetValue(NoteTitleProperty);
        set => SetValue(NoteTitleProperty, value);
    }

    public string NoteContent
    {
        get => (string)GetValue(NoteContentProperty);
        set => SetValue(NoteContentProperty, value);
    }

    public NoteItemControl()
    {
        InitializeComponent();
    }

    private async void openNote(object sender, TappedEventArgs e)
    {
        if (Shell.Current != null)
        {
            bool check = await Shell.Current.DisplayAlertAsync(NoteTitle, NoteContent, "Редагувати", "Закрити");
            if (check)
            {
                await Shell.Current.GoToAsync("editing", new Dictionary<string, object>
                {
                    ["NoteTitle"] = NoteTitle,
                    ["NoteContent"] = NoteContent
                });
            }
        }
    }
}