namespace demo1
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public bool Deleted { get; set; }
    }
}