using SQLite;

namespace NoteApp.Models
{
    public class TaskItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Content { get; set; }
        public bool IsCompleted { get; set; }
    }
}
