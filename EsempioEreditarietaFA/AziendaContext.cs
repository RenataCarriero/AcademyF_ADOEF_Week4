using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsempioEreditarietaFA
{
    internal class AziendaContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Impiegato> Impiegati { get; set; }
        public DbSet<Dirigente> Dirigenti { get; set; }

        public AziendaContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EreditarietaFA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Person>(new PersonConfiguration());
        }
    }
}
