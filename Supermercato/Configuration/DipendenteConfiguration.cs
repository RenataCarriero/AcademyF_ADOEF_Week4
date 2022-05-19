using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermercato.Models;

namespace Supermercato.Configuration
{
    internal class DipendenteConfiguration : IEntityTypeConfiguration<Dipendente>
    {
        public void Configure(EntityTypeBuilder<Dipendente> builder)
        {
            builder.ToTable("Dipendente");
            builder.Property(c => c.Codice).IsFixedLength().HasMaxLength(5);
            builder.HasKey(k => k.Codice);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Cognome).IsRequired();
            builder.Property(c => c.DataNascita).IsRequired();


            builder.HasOne(r => r.Reparto).WithMany(p => p.Dipendenti).HasForeignKey(k => k.RepartoNumero);
        }
        
    }
}