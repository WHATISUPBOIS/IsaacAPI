using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsaacAPI.Migrations
{
    /// <inheritdoc />
    public partial class Take2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseCharacter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<double>(type: "float", nullable: false),
                    Tears = table.Column<double>(type: "float", nullable: false),
                    DamageMult = table.Column<double>(type: "float", nullable: false),
                    Range = table.Column<double>(type: "float", nullable: false),
                    ShotSpeed = table.Column<double>(type: "float", nullable: false),
                    Luck = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCharacter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baseCharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_BaseCharacter_baseCharacterId",
                        column: x => x.baseCharacterId,
                        principalTable: "BaseCharacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeedUp = table.Column<double>(type: "float", nullable: false),
                    DamageUp = table.Column<double>(type: "float", nullable: false),
                    DamageMult = table.Column<double>(type: "float", nullable: false),
                    TearsUp = table.Column<double>(type: "float", nullable: false),
                    FireRateUp = table.Column<double>(type: "float", nullable: false),
                    RangeUp = table.Column<double>(type: "float", nullable: false),
                    ShotSpeedUp = table.Column<double>(type: "float", nullable: false),
                    LuckUp = table.Column<double>(type: "float", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_baseCharacterId",
                table: "Characters",
                column: "baseCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CharacterId",
                table: "Items",
                column: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "BaseCharacter");
        }
    }
}
