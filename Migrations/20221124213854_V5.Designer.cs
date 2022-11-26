﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAgency.Model;

#nullable disable

namespace TravelAgency.Migrations
{
    [DbContext(typeof(TourContext))]
    [Migration("20221124213854_V5")]
    partial class V5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("TravelAgency.Model.Agency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Name")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Agency");
                });

            modelBuilder.Entity("TravelAgency.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("AgencyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("NationalID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Phone")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TravelAgency.Model.Reservations", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TourID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TourID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TravelAgency.Model.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TravelAgency.Model.Customer", b =>
                {
                    b.HasOne("TravelAgency.Model.Agency", "Agency")
                        .WithMany("Customers")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");
                });

            modelBuilder.Entity("TravelAgency.Model.Reservations", b =>
                {
                    b.HasOne("TravelAgency.Model.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Model.Tour", "Tour")
                        .WithMany("Reservations")
                        .HasForeignKey("TourID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TravelAgency.Model.Agency", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("TravelAgency.Model.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("TravelAgency.Model.Tour", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
