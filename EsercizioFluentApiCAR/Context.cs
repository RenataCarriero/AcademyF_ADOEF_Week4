using EsercizioEFCarFluentAPI.Models;
using EsercizioFluentApiCAR.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioFluentApiCAR
{
    internal class Context: DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Person> People { get; set; }

        public Context():base()
        {

        }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EsercizioCarFluentAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Person>(new PersonConfiguration());
            modelBuilder.ApplyConfiguration<Vehicle>(new VehicleConfiguration());
        }
    }
}
