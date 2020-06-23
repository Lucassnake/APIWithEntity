using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIWithEntity.Migrations
{
    public partial class BattlesIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleHeroes",
                table: "BattleHeroes");

            migrationBuilder.DropIndex(
                name: "IX_BattleHeroes_BattleId",
                table: "BattleHeroes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BattleHeroes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleHeroes",
                table: "BattleHeroes",
                columns: new[] { "BattleId", "HeroId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleHeroes",
                table: "BattleHeroes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BattleHeroes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleHeroes",
                table: "BattleHeroes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BattleHeroes_BattleId",
                table: "BattleHeroes",
                column: "BattleId");
        }
    }
}
