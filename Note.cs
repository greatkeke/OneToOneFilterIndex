using System;

namespace demo1
{
    public class Note
    {
        public Note()
        {
        }

        public Note(string v)
        {
            Content = v;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public bool Deleted { get; set; }

        public void Update(string v)
        {
            Content = v;
        }

        public void Delete()
        {
            Deleted = true;
        }
    }
}