using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordem_Servico.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrdemServico",
                columns: table => new
                {
                    OrdemServicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataAbertura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Prazo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FormaPagamento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    TecnicoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServico", x => x.OrdemServicoID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Finalizacao",
                columns: table => new
                {
                    FinalizacaoID = table.Column<int>(type: "int", nullable: false),
                    DataFinalizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comentario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finalizacao", x => x.FinalizacaoID);
                    table.ForeignKey(
                        name: "FK_Finalizacao_OrdemServico_FinalizacaoID",
                        column: x => x.FinalizacaoID,
                        principalTable: "OrdemServico",
                        principalColumn: "OrdemServicoID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finalizacao");

            migrationBuilder.DropTable(
                name: "OrdemServico");
        }
    }
}
