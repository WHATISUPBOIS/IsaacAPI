using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsaacAPI.Migrations
{
    /// <inheritdoc />
    public partial class BaseCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_BaseCharacter_baseCharacterId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseCharacter",
                table: "BaseCharacter");

            migrationBuilder.RenameTable(
                name: "BaseCharacter",
                newName: "BaseCharacters");

            migrationBuilder.RenameColumn(
                name: "baseCharacterId",
                table: "Characters",
                newName: "BaseCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_baseCharacterId",
                table: "Characters",
                newName: "IX_Characters_BaseCharacterId");

            migrationBuilder.RenameColumn(
                name: "Tears",
                table: "BaseCharacters",
                newName: "TearsUp");

            migrationBuilder.AddColumn<double>(
                name: "BaseDamage",
                table: "BaseCharacters",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseCharacters",
                table: "BaseCharacters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_BaseCharacters_BaseCharacterId",
                table: "Characters",
                column: "BaseCharacterId",
                principalTable: "BaseCharacters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_BaseCharacters_BaseCharacterId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseCharacters",
                table: "BaseCharacters");

            migrationBuilder.DropColumn(
                name: "BaseDamage",
                table: "BaseCharacters");

            migrationBuilder.RenameTable(
                name: "BaseCharacters",
                newName: "BaseCharacter");

            migrationBuilder.RenameColumn(
                name: "BaseCharacterId",
                table: "Characters",
                newName: "baseCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_BaseCharacterId",
                table: "Characters",
                newName: "IX_Characters_baseCharacterId");

            migrationBuilder.RenameColumn(
                name: "TearsUp",
                table: "BaseCharacter",
                newName: "Tears");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseCharacter",
                table: "BaseCharacter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_BaseCharacter_baseCharacterId",
                table: "Characters",
                column: "baseCharacterId",
                principalTable: "BaseCharacter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
