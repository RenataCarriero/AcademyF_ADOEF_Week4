using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimoProgettoEF_FA.Models;

namespace PrimoProgettoEF_FA
{
    internal class EsameConfiguration : IEntityTypeConfiguration<Esame>
    {
        public void Configure(EntityTypeBuilder<Esame> builder)
        {
            builder.ToTable("Esame");
            builder.HasKey(e => e.EsameId);
            builder.Property(e => e.EsameId).HasColumnOrder(0).HasColumnName("Esame_id");
            builder.Property(e => e.Nome).HasColumnOrder(1).HasMaxLength(30).IsRequired();
            //Relazione studente esame => 1:n
            builder.HasOne(e => e.Studente).WithMany(s => s.Esami).HasForeignKey(s => s.StudentId).HasConstraintName("Fk_Studente");

        }
    }
}