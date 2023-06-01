﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhasFinancas.Domain;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MinhasFinancas.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MinhasFinancas.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool?>("Account_activated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<bool?>("Activated_by_email")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("Created_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("User_created")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("User_updated")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("User_created");

                    b.HasIndex("User_updated");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MinhasFinancas.Domain.User", b =>
                {
                    b.HasOne("MinhasFinancas.Domain.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("User_created");

                    b.HasOne("MinhasFinancas.Domain.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("User_updated");

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });
#pragma warning restore 612, 618
        }
    }
}