using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Items_ItemDBId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Items_ItemDBId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Challenges_ChallengeDBId",
                table: "Prizes");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeDBId",
                table: "Prizes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDBId",
                table: "Photos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDBId",
                table: "Parts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Votes",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Items_ItemDBId",
                table: "Parts",
                column: "ItemDBId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Items_ItemDBId",
                table: "Photos",
                column: "ItemDBId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Challenges_ChallengeDBId",
                table: "Prizes",
                column: "ChallengeDBId",
                principalTable: "Challenges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Items_ItemDBId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Items_ItemDBId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Challenges_ChallengeDBId",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "Votes",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeDBId",
                table: "Prizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDBId",
                table: "Photos",
                type: "int",
                maxLength: 500,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDBId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Items_ItemDBId",
                table: "Parts",
                column: "ItemDBId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Items_ItemDBId",
                table: "Photos",
                column: "ItemDBId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Challenges_ChallengeDBId",
                table: "Prizes",
                column: "ChallengeDBId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
