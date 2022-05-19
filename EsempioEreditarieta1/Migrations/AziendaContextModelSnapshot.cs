﻿// <auto-generated />
using EsempioEreditarieta1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EsempioEreditarieta1.Migrations
{
    [DbContext(typeof(AziendaContext))]
    partial class AziendaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EsempioEreditarieta1.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("EsempioEreditarieta1.Dirigente", b =>
                {
                    b.HasBaseType("EsempioEreditarieta1.Person");

                    b.Property<int>("NumeroDipendenti")
                        .HasColumnType("int");

                    b.Property<string>("Reporto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Dirigente");
                });

            modelBuilder.Entity("EsempioEreditarieta1.Impiegato", b =>
                {
                    b.HasBaseType("EsempioEreditarieta1.Person");

                    b.Property<int>("AnniServizio")
                        .HasColumnType("int");

                    b.Property<int>("Eta")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Impiegato");
                });
#pragma warning restore 612, 618
        }
    }
}
