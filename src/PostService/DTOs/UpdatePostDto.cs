using System.ComponentModel.DataAnnotations;

namespace PostService;

public class UpdatePostDto
{
        // public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
