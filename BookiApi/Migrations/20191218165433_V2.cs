using Microsoft.EntityFrameworkCore.Migrations;

namespace BookiApi.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Hoteis_LocalizacaoId",
                table: "Hoteis",
                column: "LocalizacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteis_Localizacoes_LocalizacaoId",
                table: "Hoteis",
                column: "LocalizacaoId",
                principalTable: "Localizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hoteis_Localizacoes_LocalizacaoId",
                table: "Hoteis");

            migrationBuilder.DropIndex(
                name: "IX_Hoteis_LocalizacaoId",
                table: "Hoteis");
        }
    }
}
