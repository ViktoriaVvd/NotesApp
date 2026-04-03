using SQLite;

namespace NoteApp.Models
{
    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
