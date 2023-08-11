using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.DTOs
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}