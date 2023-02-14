using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateMePlz.Models
{
    public class DateApplicationContext : DbContext
    {
        //Constructor
        public DateApplicationContext(DbContextOptions<DateApplicationContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<ApplicationResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    MovieID = 1,
                    Category = "Action/Adventure",
                    Title = "Avengers, The",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_To = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieID = 2,
                    Category = "Action/Adventure",
                    Title = "Dark Knight, The",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_To = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieID = 2,
                    Category = "Action/Adventure",
                    Title = "Ocean's Eleven",
                    Year = 2001,
                    Director = "Steven Soderbergh",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_To = "",
                    Notes = ""
                }
            );
        }
    }
}
