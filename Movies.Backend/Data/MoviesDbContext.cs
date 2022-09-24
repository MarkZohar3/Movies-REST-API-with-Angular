using Microsoft.EntityFrameworkCore;
using Movies.Backend.Models;

namespace Movies.Backend.Data
{
    //inherit from dbcontext
    public class MoviesDbContext : DbContext
    {
        //this constructor will pass db context options back to base class
        public MoviesDbContext(DbContextOptions options) : base(options)
        {

        }

        //dbset is a property that acts as a table in sql server - similar to dataframe in python
        public DbSet<Movie> Movies { get; set; }    




    }
}
