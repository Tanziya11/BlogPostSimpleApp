using System.Collections.Generic;

namespace BlogPostSimpleApp.Models
{
    public class PostType
    {
        public int PostTypeId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }  // "Active" or "Inactive"
        public string Description { get; set; }

        public List<Post> Posts { get; set; }
    }
}
