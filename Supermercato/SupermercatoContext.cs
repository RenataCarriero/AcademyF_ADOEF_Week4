using Microsoft.EntityFrameworkCore;
using Supermercato.Configuration;
using Supermercato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato
{
    internal class SupermercatoContext :DbContext
    {
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Reparto> Reparti { get; set; }
        public DbSet<Dipendente> Dipendenti { get; set; }
        public DbSet<Vendita> Vendite { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Supermercato;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Reparto>(new RepartoConfiguration());
            modelBuilder.ApplyConfiguration<Prodotto>(new ProdottoConfiguration());
            modelBuilder.ApplyConfiguration<Vendita>(new VenditaConfiguration());
            modelBuilder.ApplyConfiguration<Dipendente>(new DipendenteConfiguration());

        }

    }
}
