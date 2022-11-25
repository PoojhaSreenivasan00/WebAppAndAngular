using Microsoft.EntityFrameworkCore;
using SampleWebApp.Models;

namespace SampleWebApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) //this will configure the DBContext.
        {
        }

        //To create the table inside the db. To create the model inside the db, we have to create dbSet

        public DbSet<Category> Categories { get; set; }

        //The above will create the Category table with name of categories with 4 col mentioned in the model.
    }
}

//Note: While working with Entity Framework Core, there are 2 approches:- Code First and Database First.
//In  Code First approch, We will write the code in the model and Entity framework will set the same in db.(best practice)
//In Database First approch, the db tables are already created and we will call it in the model.
