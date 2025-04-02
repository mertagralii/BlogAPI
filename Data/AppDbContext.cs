using BlogAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MERT;Database=BlogAPI;Integrated Security=true;TrustServerCertificate=True");
        }
         public DbSet<Writing> Writings { get; set; }
         public DbSet<Comment> Comments { get; set; }
    }
}
