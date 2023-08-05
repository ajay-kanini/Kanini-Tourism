﻿// <auto-generated />
using System;
using Hotels_RoomsAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotels_RoomsAPI.Migrations
{
    [DbContext(typeof(HotelsContext))]
    [Migration("20230805105625_M")]
    partial class M
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hotels_RoomsAPI.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Hotels_RoomsAPI.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<bool>("ACAvailability")
                        .HasColumnType("bit");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPersons")
                        .HasColumnType("int");

                    b.Property<bool>("RoomAvailability")
                        .HasColumnType("bit");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RoomPricePerDay")
                        .HasColumnType("float");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hotels_RoomsAPI.Models.Room", b =>
                {
                    b.HasOne("Hotels_RoomsAPI.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });
#pragma warning restore 612, 618
        }
    }
}
