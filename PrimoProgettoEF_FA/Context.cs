using Microsoft.EntityFrameworkCore;
using PrimoProgettoEF_FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimoProgettoEF_FA
{
    public class Context: DbContext
    {
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Esame> Esami { get; set; }

        public Context()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroEsami;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration<Esame>(new EsameConfiguration());
            modelBuilder.ApplyConfiguration<Studente>(new StudenteConfiguration());

            ////Entità esame
            //modelBuilder.Entity<Esame>(e => e.ToTable("Esame"));
            //modelBuilder.Entity<Esame>(e => e.HasKey(e=>e.EsameId));
            //modelBuilder.Entity<Esame>(e => e.Property(e=>e.EsameId).HasColumnOrder(0).HasColumnName("Esame_id"));
            //modelBuilder.Entity<Esame>(e => e.Property(e=>e.Nome).HasColumnOrder(1).HasMaxLength(30).IsRequired());
            ////Relazione studente esame => 1:n
            //modelBuilder.Entity<Esame>(e => e.HasOne(e => e.Studente).WithMany(s => s.Esami).HasForeignKey(s => s.StudentId).HasConstraintName("Fk_Studente"));

            ////Entità Studente
            //modelBuilder.Entity<Studente>(s => s.ToTable("Studente"));
            //modelBuilder.Entity<Studente>(s => s.HasKey(s=>s.StudentId));
            //modelBuilder.Entity<Studente>(s => s.Property(s=>s.Cognome).IsRequired());
            //modelBuilder.Entity<Studente>(s => s.Property(s=>s.Nome).IsRequired());

            ////Relazione studente esame => 1:n
            //modelBuilder.Entity<Studente>(s => s.HasMany(s => s.Esami).WithOne(e => e.Studente).HasForeignKey(e => e.StudentId));
        }
    }
}
