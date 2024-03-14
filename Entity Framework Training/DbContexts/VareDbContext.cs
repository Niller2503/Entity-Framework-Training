using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Framework_Training.Vare;
using Microsoft.EntityFrameworkCore;


namespace Entity_Framework_Training.DbContexts
{
    public class VareDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NIKLASCOMPUTER\\SKOLEDB;Database= MinDb; Trusted_Connection=True;");
        }

    }
}
