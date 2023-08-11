using System.ComponentModel.DataAnnotations;

namespace PostService;

public class CreatePostDto
{
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
