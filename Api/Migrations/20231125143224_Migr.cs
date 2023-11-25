using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Migr : Migration
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    CaretakerId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    { new Guid("19f502a3-e35c-42ed-820c-7ced9a5b1d96"), 3, 3000.0 },
                    { new Guid("1e499e0a-7093-45cd-b5e9-852867cdd4b8"), 0, 1500.0 },
                    { new Guid("a6d53c8c-6fbd-47c7-8511-90f05bc89601"), 2, 1200.0 },
                    { new Guid("b17f87c2-9c50-444b-a25b-50d55d09319e"), 1, 2400.0 }
                });

            migrationBuilder.InsertData(
                table: "Caretakers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("18c5ed1d-b07c-4e17-822b-c6315de12c3f"), "Norbert", "Firanka" },
                    { new Guid("355330e3-29a7-4df2-ba85-d77ae59f19ff"), "Albert", "Szybkipuls" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("3a68e903-2458-4834-9e2f-9f6f8a6c43b0"), "skunks@skunks.com", false, "haslo123", "skunksior" },
                    { new Guid("e21c1fc4-99b7-4dfd-acaf-c46cb6b1cd2f"), "czad@man.com", true, "password", "czadoman" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "CaretakerId", "DateOfBirth", "Enclosure", "Name", "Species" },
                values: new object[,]
                {
                    { new Guid("618eb0db-d6e6-4141-9cca-0c3863e83c63"), new Guid("18c5ed1d-b07c-4e17-822b-c6315de12c3f"), new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(92), 0, "Janusz", 4 },
                    { new Guid("88c2fc03-5535-4f43-b329-bbfda7b17e20"), new Guid("18c5ed1d-b07c-4e17-822b-c6315de12c3f"), new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(90), 0, "Joe", 1 },
                    { new Guid("a3da4956-0e12-4902-ace7-2d5fc15b5d9a"), new Guid("355330e3-29a7-4df2-ba85-d77ae59f19ff"), new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(87), 3, "Zoe", 0 },
                    { new Guid("a8fe3e8b-5004-4ea1-a19e-e7ceb3ae6cad"), new Guid("355330e3-29a7-4df2-ba85-d77ae59f19ff"), new DateTime(2023, 11, 25, 15, 32, 24, 28, DateTimeKind.Local).AddTicks(9894), 1, "Tony", 3 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Date", "Enclosure", "Price", "UserId" },
                values: new object[,]
                {
                    { new Guid("5121d3db-84d5-4b73-a8ec-cdf99e6add94"), new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(127), 1, 14.5, new Guid("3a68e903-2458-4834-9e2f-9f6f8a6c43b0") },
                    { new Guid("728f5a2a-87b2-4dcc-93cf-c68d52ba0586"), new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(135), 3, 17.5, new Guid("e21c1fc4-99b7-4dfd-acaf-c46cb6b1cd2f") },
                    { new Guid("94ff25a1-7d7f-4887-85e4-22aeaf15d70d"), new DateTime(2023, 11, 25, 15, 32, 24, 29, DateTimeKind.Local).AddTicks(130), 2, 16.5, new Guid("3a68e903-2458-4834-9e2f-9f6f8a6c43b0") }
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
