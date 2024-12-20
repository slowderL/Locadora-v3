﻿// <auto-generated />
using System;
using Locadora.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Locadora.Migrations
{
    [DbContext(typeof(LocadoraContext))]
    [Migration("20241120194403_v8")]
    partial class v8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FilmeGenero", b =>
                {
                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<int>("GenId")
                        .HasColumnType("int");

                    b.HasKey("FilmeId", "GenId");

                    b.HasIndex("GenId");

                    b.ToTable("FilmeGenero", (string)null);
                });

            modelBuilder.Entity("Locadora.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Devolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Emprestimo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Locadora.Models.Genero", b =>
                {
                    b.Property<int>("GenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenId"));

                    b.Property<DateTime>("DtCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Locadora.Models.Produtora", b =>
                {
                    b.Property<int>("ProdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdId"));

                    b.Property<DateTime>("DtCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProdCnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProdId");

                    b.ToTable("Produtoras");
                });

            modelBuilder.Entity("FilmeGenero", b =>
                {
                    b.HasOne("Locadora.Models.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Locadora.Models.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Locadora.Models.Filme", b =>
                {
                    b.HasOne("Locadora.Models.Produtora", "Produtora")
                        .WithMany("Filmes")
                        .HasForeignKey("ProdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produtora");
                });

            modelBuilder.Entity("Locadora.Models.Produtora", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}
