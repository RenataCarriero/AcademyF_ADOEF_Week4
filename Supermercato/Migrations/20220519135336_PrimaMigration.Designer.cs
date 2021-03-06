// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Supermercato;

#nullable disable

namespace Supermercato.Migrations
{
    [DbContext(typeof(SupermercatoContext))]
    [Migration("20220519135336_PrimaMigration")]
    partial class PrimaMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Supermercato.Models.Dipendente", b =>
                {
                    b.Property<string>("Codice")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength();

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RepartoNumero")
                        .HasColumnType("int");

                    b.HasKey("Codice");

                    b.HasIndex("RepartoNumero");

                    b.ToTable("Dipendente", (string)null);
                });

            modelBuilder.Entity("Supermercato.Models.Prodotto", b =>
                {
                    b.Property<string>("Codice")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength();

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RepartoNumero")
                        .HasColumnType("int");

                    b.Property<string>("prodotto_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codice");

                    b.HasIndex("RepartoNumero");

                    b.ToTable("Prodotto", (string)null);

                    b.HasDiscriminator<string>("prodotto_type").HasValue("prodotto");
                });

            modelBuilder.Entity("Supermercato.Models.Reparto", b =>
                {
                    b.Property<int>("NumeroReparto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroReparto"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumeroReparto");

                    b.ToTable("Reparto", (string)null);
                });

            modelBuilder.Entity("Supermercato.Models.Vendita", b =>
                {
                    b.Property<int>("NumeroVendita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroVendita"), 1L, 1);

                    b.Property<string>("CodiceProdotto")
                        .IsRequired()
                        .HasColumnType("nchar(5)");

                    b.Property<DateTime>("DataVendita")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantita")
                        .HasColumnType("int");

                    b.HasKey("NumeroVendita");

                    b.HasIndex("CodiceProdotto");

                    b.ToTable("Vendita", (string)null);
                });

            modelBuilder.Entity("Supermercato.Models.ProdottoAlimentare", b =>
                {
                    b.HasBaseType("Supermercato.Models.Prodotto");

                    b.Property<DateTime>("DataScadenza")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("alimentare");
                });

            modelBuilder.Entity("Supermercato.Models.ProdottoCasalingo", b =>
                {
                    b.HasBaseType("Supermercato.Models.Prodotto");

                    b.Property<string>("Marchio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("casalingo");
                });

            modelBuilder.Entity("Supermercato.Models.Dipendente", b =>
                {
                    b.HasOne("Supermercato.Models.Reparto", "Reparto")
                        .WithMany("Dipendenti")
                        .HasForeignKey("RepartoNumero");

                    b.Navigation("Reparto");
                });

            modelBuilder.Entity("Supermercato.Models.Prodotto", b =>
                {
                    b.HasOne("Supermercato.Models.Reparto", "Reparto")
                        .WithMany("Prodotti")
                        .HasForeignKey("RepartoNumero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reparto");
                });

            modelBuilder.Entity("Supermercato.Models.Vendita", b =>
                {
                    b.HasOne("Supermercato.Models.Prodotto", "Prodotto")
                        .WithMany("Vendite")
                        .HasForeignKey("CodiceProdotto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prodotto");
                });

            modelBuilder.Entity("Supermercato.Models.Prodotto", b =>
                {
                    b.Navigation("Vendite");
                });

            modelBuilder.Entity("Supermercato.Models.Reparto", b =>
                {
                    b.Navigation("Dipendenti");

                    b.Navigation("Prodotti");
                });
#pragma warning restore 612, 618
        }
    }
}
