﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StripsDL;

#nullable disable

namespace StripsDL.Migrations
{
    [DbContext(typeof(StripContext))]
    [Migration("20241104175157_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuteurStrip", b =>
                {
                    b.Property<int>("AuteursId")
                        .HasColumnType("int");

                    b.Property<int>("StripsId")
                        .HasColumnType("int");

                    b.HasKey("AuteursId", "StripsId");

                    b.HasIndex("StripsId");

                    b.ToTable("AuteurStrip");
                });

            modelBuilder.Entity("StripsBL.Models.Auteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAdres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Auteurs");
                });

            modelBuilder.Entity("StripsBL.Models.Reeks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reeksen");
                });

            modelBuilder.Entity("StripsBL.Models.Strip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ReeksId")
                        .HasColumnType("int");

                    b.Property<int?>("ReeksNummer")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UitgeverijId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReeksId");

                    b.HasIndex("UitgeverijId");

                    b.ToTable("Strips");
                });

            modelBuilder.Entity("StripsBL.Models.Uitgeverij", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Uitgeverijen");
                });

            modelBuilder.Entity("AuteurStrip", b =>
                {
                    b.HasOne("StripsBL.Models.Auteur", null)
                        .WithMany()
                        .HasForeignKey("AuteursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StripsBL.Models.Strip", null)
                        .WithMany()
                        .HasForeignKey("StripsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StripsBL.Models.Strip", b =>
                {
                    b.HasOne("StripsBL.Models.Reeks", "Reeks")
                        .WithMany("Strips")
                        .HasForeignKey("ReeksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StripsBL.Models.Uitgeverij", "Uitgeverij")
                        .WithMany("Strips")
                        .HasForeignKey("UitgeverijId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reeks");

                    b.Navigation("Uitgeverij");
                });

            modelBuilder.Entity("StripsBL.Models.Reeks", b =>
                {
                    b.Navigation("Strips");
                });

            modelBuilder.Entity("StripsBL.Models.Uitgeverij", b =>
                {
                    b.Navigation("Strips");
                });
#pragma warning restore 612, 618
        }
    }
}
