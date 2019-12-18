using Microsoft.EntityFrameworkCore.Migrations;

namespace BookiApi.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoQuartoId",
                table: "Capacidades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Capacidades_TipoQuartoId",
                table: "Capacidades",
                column: "TipoQuartoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacidades_Hoteis_HotelId",
                table: "Capacidades",
                column: "HotelId",
                principalTable: "Hoteis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Capacidades_TiposQuarto_TipoQuartoId",
                table: "Capacidades",
                column: "TipoQuartoId",
                principalTable: "TiposQuarto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capacidades_Hoteis_HotelId",
                table: "Capacidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Capacidades_TiposQuarto_TipoQuartoId",
                table: "Capacidades");

            migrationBuilder.DropIndex(
                name: "IX_Capacidades_TipoQuartoId",
                table: "Capacidades");

            migrationBuilder.DropColumn(
                name: "TipoQuartoId",
                table: "Capacidades");
        }
    }
}
