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
                    { new Guid("14160af4-c8e4-4729-bf8e-b12d7531a645"), 2, 1200.0 },
                    { new Guid("3f589716-5814-470f-ab6d-5df6970a005b"), 3, 3000.0 },
                    { new Guid("5a03ce0b-b477-477c-ab59-d88bd4bca3b0"), 1, 2400.0 },
                    { new Guid("d7b9141d-7d19-4131-83cb-4aa905ddc0ca"), 0, 1500.0 }
                });

            migrationBuilder.InsertData(
                table: "Caretakers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("7a58bd01-2f55-4177-934f-5c31aad22218"), "Norbert", "Firanka" },
                    { new Guid("a39527b0-8e2e-411a-8ecf-167fbd84ab40"), "Albert", "Szybkipuls" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("9da51020-1be3-4f8c-bace-d6d51a472082"), "skunks@skunks.com", false, "haslo123", "skunksior" },
                    { new Guid("f1a6610b-655a-4b3c-a88e-8431ea67ce9b"), "czad@man.com", true, "password", "czadoman" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "CaretakerId", "DateOfBirth", "Enclosure", "Name", "Species" },
                values: new object[,]
                {
                    { new Guid("10aac724-5e33-4132-94d0-0295eb7aa433"), new Guid("a39527b0-8e2e-411a-8ecf-167fbd84ab40"), new DateTime(2023, 11, 25, 12, 42, 0, 104, DateTimeKind.Local).AddTicks(3051), 3, "Zoe", 0 },
                    { new Guid("1cfad69b-834e-47bc-ab33-a31544d171d7"), new Guid("7a58bd01-2f55-4177-934f-5c31aad22218"), new DateTime(2023, 11, 25, 12, 42, 0, 104, DateTimeKind.Local).AddTicks(3057), 0, "Janusz", 4 },
                    { new Guid("2a867b04-83bb-4b92-bf2a-630989aa6570"), new Guid("a39527b0-8e2e-411a-8ecf-167fbd84ab40"), new DateTime(2023, 11, 25, 12, 42, 0, 104, DateTimeKind.Local).AddTicks(3005), 1, "Tony", 3 },
                    { new Guid("c7006ec8-7ae1-4e66-8ad6-e5b05e368b69"), new Guid("7a58bd01-2f55-4177-934f-5c31aad22218"), new DateTime(2023, 11, 25, 12, 42, 0, 104, DateTimeKind.Local).AddTicks(3054), 0, "Joe", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Date", "Enclosure", "Price", "UserId" },
                values: new object[,]
                {
                    { new Guid("7da223f0-26cb-4e00-a811-3c862cc13ad1"), new DateTime(2023, 11, 25, 12, 42, 0, 104, DateTimeKind.Local).AddTicks(3093), 1, 14.5, new Guid("9da51020-1be3-4f8c-bace-d6d51a472082") },
                    { new Guid("85d4a056-970b-4bd6-b247-9a81499cf88f"), new DateTime(2023, 11, 25, 12, 42, 0, 104, DateTimeKind.Local).AddTicks(3101), 3, 17.5, new Guid("f1a6610b-655a-4b3c-a88e-8431ea67ce9b") },
                    { new Guid("e8520710-2754-4bf3-98f5-de97090d9cfd"), new DateTime(2023, 11, 25, 12, 42, 0, 104, DateTimeKind.Local).AddTicks(3099), 2, 16.5, new Guid("9da51020-1be3-4f8c-bace-d6d51a472082") }
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
