﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Quality2.Database;

#nullable disable

namespace Quality2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230730120341_ExtruderAdd")]
    partial class ExtruderAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Quality2.Entities.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Thickness")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("Mark", "Thickness", "Color");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("Quality2.Entities.FilmProperties", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<decimal>("CoefficientOfFrictionD")
                        .HasColumnType("numeric");

                    b.Property<double>("CoefficientOfFrictionS")
                        .HasColumnType("double precision");

                    b.Property<int>("CoronaTreatment")
                        .HasColumnType("integer");

                    b.Property<int>("ElongationAtBreakMD")
                        .HasColumnType("integer");

                    b.Property<int>("ElongationAtBreakTD")
                        .HasColumnType("integer");

                    b.Property<int>("LightTransmission")
                        .HasColumnType("integer");

                    b.Property<int>("MaxThickness")
                        .HasColumnType("integer");

                    b.Property<int>("MinThickness")
                        .HasColumnType("integer");

                    b.Property<int>("TensileStrengthMD")
                        .HasColumnType("integer");

                    b.Property<int>("TensileStrengthTD")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("FilmProperties");
                });

            modelBuilder.Entity("Quality2.Entities.OrderQuality", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("BrigadeNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Customer")
                        .HasColumnType("text");

                    b.Property<string>("ExtruderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FilmID")
                        .HasColumnType("integer");

                    b.Property<int?>("FilmPropertyID")
                        .HasColumnType("integer");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("ProductionDate")
                        .HasColumnType("date");

                    b.Property<int>("RollNumber")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("FilmPropertyID");

                    b.ToTable("OrderQuality");
                });

            modelBuilder.Entity("Quality2.Entities.StandartQualityFilm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("FilmID")
                        .HasColumnType("integer");

                    b.Property<int>("FilmPropertyID")
                        .HasColumnType("integer");

                    b.Property<string>("StandartName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("FilmPropertyID");

                    b.HasIndex("FilmID", "StandartName");

                    b.ToTable("StandartQuality");
                });

            modelBuilder.Entity("Quality2.Entities.OrderQuality", b =>
                {
                    b.HasOne("Quality2.Entities.FilmProperties", "FilmProperty")
                        .WithMany()
                        .HasForeignKey("FilmPropertyID");

                    b.Navigation("FilmProperty");
                });

            modelBuilder.Entity("Quality2.Entities.StandartQualityFilm", b =>
                {
                    b.HasOne("Quality2.Entities.FilmProperties", "FilmProperty")
                        .WithMany()
                        .HasForeignKey("FilmPropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmProperty");
                });
#pragma warning restore 612, 618
        }
    }
}
