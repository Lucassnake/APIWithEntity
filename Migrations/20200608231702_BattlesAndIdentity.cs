using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIWithEntity.Migrations
{
    public partial class BattlesAndIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Battles_BattleId",
                table: "Heros");

            migrationBuilder.DropIndex(
                name: "IX_Heros_BattleId",
                table: "Heros");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Heros");

            migrationBuilder.CreateTable(
                name: "BattleHeroes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeroId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleHeroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleHeroes_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleHeroes_Heros_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecretIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RealName = table.Column<string>(nullable: true),
                    HeroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretIdentities_Heros_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleHeroes_BattleId",
                table: "BattleHeroes",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleHeroes_HeroId",
                table: "BattleHeroes",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentities_HeroId",
                table: "SecretIdentities",
                column: "HeroId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleHeroes");

            migrationBuilder.DropTable(
                name: "SecretIdentities");

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Heros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Heros_BattleId",
                table: "Heros",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Battles_BattleId",
                table: "Heros",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
