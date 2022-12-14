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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var entityBuilder = builder.Entity<User>();
            //entityBuilder.Property<int>("Id");
            entityBuilder.Property(b => b.Id)
                .HasField("_id");
            entityBuilder.Property(b => b.Name)
                .HasField("_name");
            entityBuilder.Property(b => b.Age)
                .HasField("_age");
            entityBuilder.Property(b => b.PhoneNo)
                .HasField("_phoneNo");



            base.OnModelCreating(builder);


        }
    }

    
}
