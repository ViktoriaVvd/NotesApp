using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace NoteApp.Models
{
    public partial class TaskItem : ObservableObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        [ObservableProperty]
        public partial bool Completed { get; set; }
    }
}
