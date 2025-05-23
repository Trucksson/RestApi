﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApi.Data;

#nullable disable

namespace RestApi.Migrations
{
    [DbContext(typeof(CVContext))]
    [Migration("20250514154705_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestApi.Models.Arbetserfarenhet", b =>
                {
                    b.Property<int>("ArbetserfarenhetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArbetserfarenhetID"));

                    b.Property<string>("Företag")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Jobbbeskrivning")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("Jobbslut")
                        .HasColumnType("date");

                    b.Property<DateOnly>("Jobbstart")
                        .HasColumnType("date");

                    b.Property<string>("Jobbtitel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PerosonID_FK")
                        .HasColumnType("int");

                    b.HasKey("ArbetserfarenhetID");

                    b.HasIndex("PerosonID_FK");

                    b.ToTable("Arbetserfarenheter");
                });

            modelBuilder.Entity("RestApi.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Beskrivning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Epost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobilnummer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PersonId");

                    b.ToTable("Personer");
                });

            modelBuilder.Entity("RestApi.Models.Utbildning", b =>
                {
                    b.Property<int>("UtbildningID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UtbildningID"));

                    b.Property<int>("PersonId_FK")
                        .HasColumnType("int");

                    b.Property<string>("Skola")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UtbildningBeskrivning")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UtbildningExamen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("UtbildningSlut")
                        .HasColumnType("date");

                    b.Property<DateOnly>("UtbildningStart")
                        .HasColumnType("date");

                    b.HasKey("UtbildningID");

                    b.HasIndex("PersonId_FK");

                    b.ToTable("Utbildningar");
                });

            modelBuilder.Entity("RestApi.Models.Arbetserfarenhet", b =>
                {
                    b.HasOne("RestApi.Models.Person", "Person")
                        .WithMany("Arbetserfarenheter")
                        .HasForeignKey("PerosonID_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("RestApi.Models.Utbildning", b =>
                {
                    b.HasOne("RestApi.Models.Person", "Person")
                        .WithMany("Utbildningar")
                        .HasForeignKey("PersonId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("RestApi.Models.Person", b =>
                {
                    b.Navigation("Arbetserfarenheter");

                    b.Navigation("Utbildningar");
                });
#pragma warning restore 612, 618
        }
    }
}
