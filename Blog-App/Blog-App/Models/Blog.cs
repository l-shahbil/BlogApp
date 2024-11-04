using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_App.Models
{
    [Table("Blogs")]
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string image {  get; set; }
        public bool IsFeatured { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
