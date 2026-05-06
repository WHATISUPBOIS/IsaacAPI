using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsaacAPI.Migrations
{
    /// <inheritdoc />
    public partial class ItemCharacterFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterItem_Characters_CharactersId",
                table: "CharacterItem");

            migrationBuilder.RenameColumn(
                name: "CharactersId",
                table: "CharacterItem",
                newName: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterItem_Characters_CharacterId",
                table: "CharacterItem",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterItem_Characters_CharacterId",
                table: "CharacterItem");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "CharacterItem",
                newName: "CharactersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterItem_Characters_CharactersId",
                table: "CharacterItem",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
