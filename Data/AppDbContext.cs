using HelloApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Message> Messages => Set<Message>();
    }
}
