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
        public DbSet<Category> Categories { get; set; }

        // Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                    new Category { CategoryId = 2, CategoryName = "Comedy"},
                    new Category { CategoryId = 3, CategoryName = "Drama" },
                    new Category { CategoryId = 4, CategoryName = "Family" },
                    new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                    new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                    new Category { CategoryId = 7, CategoryName = "Television" },
                    new Category { CategoryId = 8, CategoryName = "VHS" }
                );
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    MovieID = 1,
                    CategoryId = 1,
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
                    CategoryId = 1,
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
                    MovieID = 3,
                    CategoryId = 1,
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
