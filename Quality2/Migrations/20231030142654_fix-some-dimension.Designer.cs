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
    [Migration("20231030142654_fix-some-dimension")]
    partial class fixsomedimension
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Quality2.Database.Extruder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ExtruderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("ExtruderName")
                        .IsUnique();

                    b.ToTable("Extruder");
                });

            modelBuilder.Entity("Quality2.Database.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Density")
                        .HasColumnType("double precision");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Thickness")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("Mark", "Thickness", "Color")
                        .IsUnique();

                    b.ToTable("Film");
                });

            modelBuilder.Entity("Quality2.Database.OrderQuality", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("BrigadeNumber")
                        .HasColumnType("integer");

                    b.Property<double>("CoefficientOfFrictionD")
                        .HasColumnType("double precision");

                    b.Property<double>("CoefficientOfFrictionS")
                        .HasColumnType("double precision");

                    b.Property<int>("CoronaTreatment")
                        .HasColumnType("integer");

                    b.Property<string>("Customer")
                        .HasColumnType("text");

                    b.Property<int>("ElongationAtBreakMD")
                        .HasColumnType("integer");

                    b.Property<int>("ElongationAtBreakTD")
                        .HasColumnType("integer");

                    b.Property<int>("ExtruderID")
                        .HasColumnType("integer");

                    b.Property<int>("FilmID")
                        .HasColumnType("integer");

                    b.Property<int>("LightTransmission")
                        .HasColumnType("integer");

                    b.Property<int>("MaxThickness")
                        .HasColumnType("integer");

                    b.Property<int>("MinThickness")
                        .HasColumnType("integer");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("ProductionDate")
                        .HasColumnType("date");

                    b.Property<int>("RollNumber")
                        .HasColumnType("integer");

                    b.Property<int>("StandartQualityNameID")
                        .HasColumnType("integer");

                    b.Property<double>("TensileStrengthMD")
                        .HasColumnType("double precision");

                    b.Property<double>("TensileStrengthTD")
                        .HasColumnType("double precision");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("OrderQuality");
                });

            modelBuilder.Entity("Quality2.Database.StandartQualityFilm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<double>("CoefficientOfFrictionD")
                        .HasColumnType("double precision");

                    b.Property<double>("CoefficientOfFrictionS")
                        .HasColumnType("double precision");

                    b.Property<int>("CoronaTreatment")
                        .HasColumnType("integer");

                    b.Property<int>("ElongationAtBreakMD")
                        .HasColumnType("integer");

                    b.Property<int>("ElongationAtBreakTD")
                        .HasColumnType("integer");

                    b.Property<int>("FilmID")
                        .HasColumnType("integer");

                    b.Property<int?>("LightTransmission")
                        .HasColumnType("integer");

                    b.Property<int>("StandartQualityNameID")
                        .HasColumnType("integer");

                    b.Property<double>("TensileStrengthMD")
                        .HasColumnType("double precision");

                    b.Property<double>("TensileStrengthTD")
                        .HasColumnType("double precision");

                    b.Property<double>("ThicknessVariation")
                        .HasColumnType("double precision");

                    b.HasKey("ID");

                    b.HasIndex("FilmID", "StandartQualityNameID")
                        .IsUnique();

                    b.ToTable("StandartQuality");
                });

            modelBuilder.Entity("Quality2.Database.StandartQualityName", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("StandartQualityName");
                });

            modelBuilder.Entity("Quality2.Database.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
