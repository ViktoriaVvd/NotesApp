using SQLite;

namespace NoteApp.Models
{
    public class NoteItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}
