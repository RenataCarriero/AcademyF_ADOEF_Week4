using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermercato.Models;

namespace Supermercato.Configuration
{
    internal class RepartoConfiguration : IEntityTypeConfiguration<Reparto>
    {
        public void Configure(EntityTypeBuilder<Reparto> builder)
        {
            builder.ToTable("Reparto");
            builder.HasKey(k => k.NumeroReparto);
            builder.Property(c => c.Nome).IsRequired();
        }
    }
}