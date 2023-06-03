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

            modelBuilder.Entity("MinhasFinancas.Domain.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount_received_per_month")
                        .HasColumnType("double precision");

                    b.Property<double>("Available_value")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime?>("Created_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid>("Responsible_user")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Value_credit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0);

                    b.HasKey("Id");

                    b.HasIndex("Responsible_user");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("MinhasFinancas.Domain.TabelsOfRelation.UserAsAccount", b =>
                {
                    b.Property<Guid>("Account_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("User_id")
                        .HasColumnType("uuid");

                    b.HasKey("Account_id", "User_id");

                    b.HasIndex("User_id");

                    b.ToTable("User_has_account");
                });

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
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea")
                        .HasColumnName("Password_salt");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MinhasFinancas.Domain.Account", b =>
                {
                    b.HasOne("MinhasFinancas.Domain.User", "User")
                        .WithMany("Users_account")
                        .HasForeignKey("Responsible_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MinhasFinancas.Domain.TabelsOfRelation.UserAsAccount", b =>
                {
                    b.HasOne("MinhasFinancas.Domain.Account", null)
                        .WithMany()
                        .HasForeignKey("Account_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinhasFinancas.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinhasFinancas.Domain.User", b =>
                {
                    b.Navigation("Users_account");
                });
#pragma warning restore 612, 618
        }
    }
}
