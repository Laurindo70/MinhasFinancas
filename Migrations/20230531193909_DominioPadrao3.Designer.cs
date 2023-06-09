﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhasFinancas.Domain;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MinhasFinancas.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230531193909_DominioPadrao3")]
    partial class DominioPadrao3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MinhasFinancas.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CriadoPor")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CriadoPor");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MinhasFinancas.Models.Usuario", b =>
                {
                    b.HasOne("MinhasFinancas.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("CriadoPor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
