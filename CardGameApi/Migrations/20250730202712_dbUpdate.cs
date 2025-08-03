using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardGameApi.Migrations
{
    /// <inheritdoc />
    public partial class dbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Players_PlayerId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_GameId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Cards_PlayerId",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Cards",
                newName: "IsInDeck");

            migrationBuilder.AddColumn<string>(
                name: "CardId",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "CardId",
                table: "Games",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "Games",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<bool>(
                name: "isComplete",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DeckNumber",
                table: "Cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "isComplete",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DeckNumber",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "IsInDeck",
                table: "Cards",
                newName: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PlayerId",
                table: "Cards",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Players_PlayerId",
                table: "Cards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
