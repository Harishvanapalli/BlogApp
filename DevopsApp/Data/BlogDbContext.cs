using DevopsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DevopsApp.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
                
        }

        public DbSet<BlogModel> BlogTable { get; set; }
    }
}
