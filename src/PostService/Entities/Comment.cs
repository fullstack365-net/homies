using System.ComponentModel.DataAnnotations.Schema;
using PostService.Entities;

namespace PostService;

[Table("Comments")]
public class Comment
{
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Post Post { get; set; }
        public Guid PostId { get; set; }
}
