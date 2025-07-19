using System.Collections.Generic;

namespace BlogPostSimpleApp.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public bool isPublic { get; set; }

        // Foreign Key
        public int BlogTypeId { get; set; }
        public BlogType BlogType { get; set; }

        // Navigation
        public List<Post> Posts { get; set; }
    }
}