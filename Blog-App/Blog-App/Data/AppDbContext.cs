using Blog_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_App.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<user> Users { get; set; }
    }
}
