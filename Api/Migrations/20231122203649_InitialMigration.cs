using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Enclosure = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caretakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caretakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Species = table.Column<int>(type: "INTEGER", nullable: false),
                    Enclosure = table.Column<int>(type: "INTEGER", nullable: false),
                    CaretakerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Caretakers_CaretakerId",
                        column: x => x.CaretakerId,
                        principalTable: "Caretakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Enclosure = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AvailableTickets",
                columns: new[] { "Id", "Enclosure", "Price" },
                values: new object[,]
                {
                    { new Guid("89db1c2a-706c-4079-af5c-fa7f9cbd6ac9"), 3, 3000.0 },
                    { new Guid("ba0e8b56-7429-41cd-a3c6-848d539cc730"), 0, 1500.0 },
                    { new Guid("de2bf75e-7300-4c29-8a5c-e457037bfaf3"), 1, 2400.0 },
                    { new Guid("e9442f28-227e-4829-8601-bf3ef116f8d4"), 2, 1200.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CaretakerId",
                table: "Animals",
                column: "CaretakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "AvailableTickets");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Caretakers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
