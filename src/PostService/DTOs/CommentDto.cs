using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.DTOs
{
    public class CommentDto
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}