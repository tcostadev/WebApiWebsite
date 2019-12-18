using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookiApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capacidades",
                columns: table => new
                {
                    TarifasHotelId = table.Column<int>(nullable: false),
                    HotelId = table.Column<int>(nullable: false),
                    NrQuartosDisponiveis = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Hoteis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    CodPostal = table.Column<string>(nullable: true),
                    Classificacao = table.Column<float>(nullable: false),
                    LocalizacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalizacaoDs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposQuarto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designacao = table.Column<string>(nullable: true),
                    Capacidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposQuarto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    CodigoPostal = table.Column<string>(nullable: true),
                    LocalizacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarifas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoQuartoId = table.Column<int>(nullable: false),
                    Preco = table.Column<float>(nullable: false),
                    HotelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarifas_Hoteis_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarifas_TiposQuarto_TipoQuartoId",
                        column: x => x.TipoQuartoId,
                        principalTable: "TiposQuarto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    NrHospedes = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    TarifaHotelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UserId",
                table: "Reservas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifas_HotelId",
                table: "Tarifas",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifas_TipoQuartoId",
                table: "Tarifas",
                column: "TipoQuartoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capacidades");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Tarifas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Hoteis");

            migrationBuilder.DropTable(
                name: "TiposQuarto");
        }
    }
}
