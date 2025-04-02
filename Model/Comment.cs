using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace BlogAPI.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentedAt { get; set; } = DateTime.Now;
        public int WritingId { get; set; }

        [JsonIgnore] // Bu sayede Swagger bu property'yi göstermez
        [ValidateNever] // Bu property'nin validasyonunu yapmaz
        public Writing? Writing { get; set; }
    }
}
