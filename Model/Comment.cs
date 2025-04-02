namespace BlogAPI.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentedAt { get; set; } = DateTime.Now;

     
        public Writing Writing { get; set; }
    }
}
