using Microsoft.EntityFrameworkCore;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    public class ApplicationDbcontext : DbContext
    {
        public DbSet<movie> movies { get; set; }
        public DbSet<seats> seats { get; set; }
        public DbSet<servedhall> servedhalls { get; set; }
        public DbSet<showtime> showtime { get; set; }
        public DbSet<reservations> reservations { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<hall> hall { get; set; }
        public DbSet<showtimeseats> showtimeseats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AALAA1\\MSSQLSERVER01;Database=Movie;Trusted_Connection=True;MultipleActiveResultSets=true");
        }



    }
}
