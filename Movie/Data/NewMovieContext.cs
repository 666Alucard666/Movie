using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie.Models;

namespace Movie.Data
{
    public class NewMovieContext:DbContext
    {
        public DbSet<NewMovieDataDetail> NewMovies { get; set; }
        public NewMovieContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = SerialDB; User ID = Admin; Password = qwerty122;");
        }
    }
}
