using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermercato.Models;

namespace Supermercato.Configuration
{
    internal class VenditaConfiguration : IEntityTypeConfiguration<Vendita>
    {
        public void Configure(EntityTypeBuilder<Vendita> builder)
        {
            builder.ToTable("Vendita");
            builder.HasKey(k => k.NumeroVendita);
            builder.Property(c => c.DataVendita).IsRequired();
            builder.Property(c => c.Quantita).IsRequired();
            builder.HasOne(r => r.Prodotto).WithMany(p => p.Vendite).HasForeignKey(k => k.CodiceProdotto);
        }
    }
}