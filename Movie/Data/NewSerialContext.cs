using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie.Models;

namespace Movie.Data
{
    public class NewSerialContext : DbContext
    {
        public DbSet<NewSerialDataDetail> NewSerials { get; set; }
        public NewSerialContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = MovieDB; User ID = Admin; Password = qwerty122;");
        }
    }
}
