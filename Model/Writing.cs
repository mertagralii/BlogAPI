using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace BlogAPI.Model
{
    public class Writing
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
        [ValidateNever]
        public List<Comment>? Comments { get; set; } = new List<Comment>();
    }
}
