using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_App.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
