using Microsoft.EntityFrameworkCore.Migrations;

namespace BookiApi.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_Capacidades",
                table: "Capacidades",
                columns: new[] { "HotelId", "TarifasHotelId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Capacidades",
                table: "Capacidades");
        }
    }
}
