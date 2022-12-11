// Creating Database Context
using DemoProject.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoProject
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }  
    }
}
