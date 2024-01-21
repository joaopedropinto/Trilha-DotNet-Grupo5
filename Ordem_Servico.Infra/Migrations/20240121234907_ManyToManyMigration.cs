using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordem_Servico.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Marca = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modelo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DadosAdicionais = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DefeitoDeclarado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Solucao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.EquipamentoID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ocorrencia",
                columns: table => new
                {
                    OcorrenciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Situacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataHora = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencia", x => x.OcorrenciaID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Peca",
                columns: table => new
                {
                    PecaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descrição = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peca", x => x.PecaID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    ServicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.ServicoID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EquipamentoOrdemServico",
                columns: table => new
                {
                    EquipamentosEquipamentoID = table.Column<int>(type: "int", nullable: false),
                    OrdemServicosOrdemServicoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoOrdemServico", x => new { x.EquipamentosEquipamentoID, x.OrdemServicosOrdemServicoID });
                    table.ForeignKey(
                        name: "FK_EquipamentoOrdemServico_Equipamento_EquipamentosEquipamentoID",
                        column: x => x.EquipamentosEquipamentoID,
                        principalTable: "Equipamento",
                        principalColumn: "EquipamentoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipamentoOrdemServico_OrdemServico_OrdemServicosOrdemServi~",
                        column: x => x.OrdemServicosOrdemServicoID,
                        principalTable: "OrdemServico",
                        principalColumn: "OrdemServicoID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OcorrenciaOrdemServico",
                columns: table => new
                {
                    OcorrenciasOcorrenciaID = table.Column<int>(type: "int", nullable: false),
                    OrdemServicosOrdemServicoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcorrenciaOrdemServico", x => new { x.OcorrenciasOcorrenciaID, x.OrdemServicosOrdemServicoID });
                    table.ForeignKey(
                        name: "FK_OcorrenciaOrdemServico_Ocorrencia_OcorrenciasOcorrenciaID",
                        column: x => x.OcorrenciasOcorrenciaID,
                        principalTable: "Ocorrencia",
                        principalColumn: "OcorrenciaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OcorrenciaOrdemServico_OrdemServico_OrdemServicosOrdemServic~",
                        column: x => x.OrdemServicosOrdemServicoID,
                        principalTable: "OrdemServico",
                        principalColumn: "OrdemServicoID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrdemServicoPeca",
                columns: table => new
                {
                    OrdemServicosOrdemServicoID = table.Column<int>(type: "int", nullable: false),
                    PecasPecaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServicoPeca", x => new { x.OrdemServicosOrdemServicoID, x.PecasPecaID });
                    table.ForeignKey(
                        name: "FK_OrdemServicoPeca_OrdemServico_OrdemServicosOrdemServicoID",
                        column: x => x.OrdemServicosOrdemServicoID,
                        principalTable: "OrdemServico",
                        principalColumn: "OrdemServicoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServicoPeca_Peca_PecasPecaID",
                        column: x => x.PecasPecaID,
                        principalTable: "Peca",
                        principalColumn: "PecaID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrdemServicoServico",
                columns: table => new
                {
                    OrdemServicosOrdemServicoID = table.Column<int>(type: "int", nullable: false),
                    ServicosServicoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServicoServico", x => new { x.OrdemServicosOrdemServicoID, x.ServicosServicoID });
                    table.ForeignKey(
                        name: "FK_OrdemServicoServico_OrdemServico_OrdemServicosOrdemServicoID",
                        column: x => x.OrdemServicosOrdemServicoID,
                        principalTable: "OrdemServico",
                        principalColumn: "OrdemServicoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServicoServico_Servico_ServicosServicoID",
                        column: x => x.ServicosServicoID,
                        principalTable: "Servico",
                        principalColumn: "ServicoID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoOrdemServico_OrdemServicosOrdemServicoID",
                table: "EquipamentoOrdemServico",
                column: "OrdemServicosOrdemServicoID");

            migrationBuilder.CreateIndex(
                name: "IX_OcorrenciaOrdemServico_OrdemServicosOrdemServicoID",
                table: "OcorrenciaOrdemServico",
                column: "OrdemServicosOrdemServicoID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicoPeca_PecasPecaID",
                table: "OrdemServicoPeca",
                column: "PecasPecaID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicoServico_ServicosServicoID",
                table: "OrdemServicoServico",
                column: "ServicosServicoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipamentoOrdemServico");

            migrationBuilder.DropTable(
                name: "OcorrenciaOrdemServico");

            migrationBuilder.DropTable(
                name: "OrdemServicoPeca");

            migrationBuilder.DropTable(
                name: "OrdemServicoServico");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "Peca");

            migrationBuilder.DropTable(
                name: "Servico");
        }
    }
}
