using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DefaultPicture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ChallengeDBId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Challenges_ChallengeDBId",
                        column: x => x.ChallengeDBId,
                        principalTable: "Challenges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ChallengeDBId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prizes_Challenges_ChallengeDBId",
                        column: x => x.ChallengeDBId,
                        principalTable: "Challenges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ItemDBId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Parts_Items_ItemDBId",
                        column: x => x.ItemDBId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ItemId = table.Column<int>(type: "int", maxLength: 500, nullable: false),
                    ItemDBId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Location);
                    table.ForeignKey(
                        name: "FK_Photos_Items_ItemDBId",
                        column: x => x.ItemDBId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ChallengeDBId",
                table: "Items",
                column: "ChallengeDBId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ItemDBId",
                table: "Parts",
                column: "ItemDBId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ItemDBId",
                table: "Photos",
                column: "ItemDBId");

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_ChallengeDBId",
                table: "Prizes",
                column: "ChallengeDBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Prizes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Challenges");
        }
    }
}
