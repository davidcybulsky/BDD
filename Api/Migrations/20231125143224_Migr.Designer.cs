﻿// <auto-generated />
using System;
using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(SafariContext))]
    [Migration("20231125143224_Migr")]
    partial class Migr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Api.Entities.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CaretakerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<int>("Enclosure")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Species")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CaretakerId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a8fe3e8b-5004-4ea1-a19e-e7ceb3ae6cad"),
                            CaretakerId = new Guid("355330e3-29a7-4df2-ba85-d77ae59f19ff"),
                            DateOfBirth = new DateTime(2023, 11, 25, 15, 32, 24, 28, DateTimeKind.Local).AddTicks(9894),
                            Enclosure = 1,
                            Name = "Tony",
                            Species = 3
                        },
                        new
                        {
                            Id = new Guid("a3da4956-0e12-4902-ace7-2d5fc15b5d9a"),
                            CaretakerId = new Guid("355330e3-29a7-4df2-ba85-d77ae59f19ff"),
                            DateOfBirth = new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(87),
                            Enclosure = 3,
                            Name = "Zoe",
                            Species = 0
                        },
                        new
                        {
                            Id = new Guid("88c2fc03-5535-4f43-b329-bbfda7b17e20"),
                            CaretakerId = new Guid("18c5ed1d-b07c-4e17-822b-c6315de12c3f"),
                            DateOfBirth = new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(90),
                            Enclosure = 0,
                            Name = "Joe",
                            Species = 1
                        },
                        new
                        {
                            Id = new Guid("618eb0db-d6e6-4141-9cca-0c3863e83c63"),
                            CaretakerId = new Guid("18c5ed1d-b07c-4e17-822b-c6315de12c3f"),
                            DateOfBirth = new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(92),
                            Enclosure = 0,
                            Name = "Janusz",
                            Species = 4
                        });
                });

            modelBuilder.Entity("Api.Entities.AvailableTicket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Enclosure")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("AvailableTickets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1e499e0a-7093-45cd-b5e9-852867cdd4b8"),
                            Enclosure = 0,
                            Price = 1500.0
                        },
                        new
                        {
                            Id = new Guid("b17f87c2-9c50-444b-a25b-50d55d09319e"),
                            Enclosure = 1,
                            Price = 2400.0
                        },
                        new
                        {
                            Id = new Guid("a6d53c8c-6fbd-47c7-8511-90f05bc89601"),
                            Enclosure = 2,
                            Price = 1200.0
                        },
                        new
                        {
                            Id = new Guid("19f502a3-e35c-42ed-820c-7ced9a5b1d96"),
                            Enclosure = 3,
                            Price = 3000.0
                        });
                });

            modelBuilder.Entity("Api.Entities.Caretaker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Caretakers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("355330e3-29a7-4df2-ba85-d77ae59f19ff"),
                            FirstName = "Albert",
                            LastName = "Szybkipuls"
                        },
                        new
                        {
                            Id = new Guid("18c5ed1d-b07c-4e17-822b-c6315de12c3f"),
                            FirstName = "Norbert",
                            LastName = "Firanka"
                        });
                });

            modelBuilder.Entity("Api.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Enclosure")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5121d3db-84d5-4b73-a8ec-cdf99e6add94"),
                            Date = new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(127),
                            Enclosure = 1,
                            Price = 14.5,
                            UserId = new Guid("3a68e903-2458-4834-9e2f-9f6f8a6c43b0")
                        },
                        new
                        {
                            Id = new Guid("94ff25a1-7d7f-4887-85e4-22aeaf15d70d"),
                            Date = new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(130),
                            Enclosure = 2,
                            Price = 16.5,
                            UserId = new Guid("3a68e903-2458-4834-9e2f-9f6f8a6c43b0")
                        },
                        new
                        {
                            Id = new Guid("728f5a2a-87b2-4dcc-93cf-c68d52ba0586"),
                            Date = new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(135),
                            Enclosure = 3,
                            Price = 17.5,
                            UserId = new Guid("e21c1fc4-99b7-4dfd-acaf-c46cb6b1cd2f")
                        });
                });

            modelBuilder.Entity("Api.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a68e903-2458-4834-9e2f-9f6f8a6c43b0"),
                            Email = "skunks@skunks.com",
                            IsAdmin = false,
                            Password = "haslo123",
                            Username = "skunksior"
                        },
                        new
                        {
                            Id = new Guid("e21c1fc4-99b7-4dfd-acaf-c46cb6b1cd2f"),
                            Email = "czad@man.com",
                            IsAdmin = true,
                            Password = "password",
                            Username = "czadoman"
                        });
                });

            modelBuilder.Entity("Api.Entities.Animal", b =>
                {
                    b.HasOne("Api.Entities.Caretaker", "Caretaker")
                        .WithMany("Animals")
                        .HasForeignKey("CaretakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caretaker");
                });

            modelBuilder.Entity("Api.Entities.Ticket", b =>
                {
                    b.HasOne("Api.Entities.User", "user")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Api.Entities.Caretaker", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Api.Entities.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
