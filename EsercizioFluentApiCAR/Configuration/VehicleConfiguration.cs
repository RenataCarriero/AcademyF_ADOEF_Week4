using EsercizioEFCarFluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsercizioFluentApiCAR.Configuration
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            //Entità veicolo
            builder.ToTable("Veicolo");
            builder.HasKey(e => e.Targa);
            builder.Property(e => e.Targa).HasColumnOrder(0);
            builder.Property(e => e.Marca).HasMaxLength(30).IsRequired();            


            //Relazione persona veicolo => 1:n
            builder.HasOne(e => e.Person).WithMany(s => s.Vehicles).HasForeignKey(s => s.PersonCodiceFiscale).HasConstraintName("Fk_Person");
        }
    }
}