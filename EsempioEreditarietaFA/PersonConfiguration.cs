using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsempioEreditarietaFA
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persona");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Cognome).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(30);
            //Per gestire la gerarchia
            //builder.HasDiscriminator<string>("Type")
            //    .HasValue<Person>("persona")
            //    .HasValue<Impiegato>("impieg")
            //    .HasValue<Dirigente>("capo");

            builder.HasDiscriminator<int>("Type")
                .HasValue<Person>(0)
                .HasValue<Impiegato>(1)
                .HasValue<Dirigente>(2);
        }
    }
}