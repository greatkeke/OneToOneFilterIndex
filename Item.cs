using System;

namespace demo1
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Note Note { get; set; }

        public Note AddNote(string v)
        {
            if (Note == null)
            {
                Note = new Note(v);
            }
            else
            {
                Note.Update(v);
            }

            return Note;
        }

        public void DeleteNote()
        {
            Note.Delete();
        }
    }
}