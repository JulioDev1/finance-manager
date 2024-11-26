using finance_manager.Model;
using Microsoft.EntityFrameworkCore;

namespace finance_manager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users {  get; set; } 

    }
}
