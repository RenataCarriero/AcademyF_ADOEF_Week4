using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimoProgettoEF_FA.Models;

namespace PrimoProgettoEF_FA
{
    internal class StudenteConfiguration : IEntityTypeConfiguration<Studente>
    {
        public void Configure(EntityTypeBuilder<Studente> builder)
        {
            //Entità Studente
            builder.ToTable("Studente");
            builder.HasKey(s => s.StudentId);
            builder.Property(s => s.Cognome).IsRequired();
            builder.Property(s => s.Nome).IsRequired();

            //Relazione studente esame => 1:n
            builder.HasMany(s => s.Esami).WithOne(e => e.Studente).HasForeignKey(e => e.StudentId);
        }
    }
}