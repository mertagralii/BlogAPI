namespace BlogAPI.Model
{
    public class Writing
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
