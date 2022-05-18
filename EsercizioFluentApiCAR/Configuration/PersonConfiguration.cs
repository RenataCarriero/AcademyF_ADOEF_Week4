using EsercizioEFCarFluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsercizioFluentApiCAR.Configuration
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //Entità Person
            builder.ToTable("Persona");
            builder.HasKey(e => e.CodiceFiscale);
            builder.Property("CodiceFiscale").HasMaxLength(16).IsFixedLength();
            builder.Property(e => e.Cognome).IsRequired();
            builder.Property(e => e.Nome).IsRequired();
            builder.Property(e => e.DataNascita).IsRequired(false);
            

            //relazione persona veicolo => 1:n

            builder.HasMany(e => e.Vehicles).WithOne(e => e.Person).HasForeignKey(e => e.PersonCodiceFiscale);

            //Pre - caricamento dei dati
            builder.HasData(
                new Person
                {
                    CodiceFiscale="ABCDEF1234567890",
                    Nome = "Mario",
                    Cognome = "Rossi",
                    DataNascita = new DateTime(1980, 1, 1)
                    
                },
                new Person
                {
                    CodiceFiscale= "1234567890AAAAAA",
                    Nome = "Luca",
                    Cognome = "Verdi",
                    DataNascita = new DateTime(1990, 2, 2)                    
                }
            );

        }
    }
}