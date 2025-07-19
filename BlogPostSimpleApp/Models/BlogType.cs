using System.Collections.Generic;

namespace BlogPostSimpleApp.Models
{
    public class BlogType
    {
        public int BlogTypeId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }  // "Active" or "Inactive"
        public string Description { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}