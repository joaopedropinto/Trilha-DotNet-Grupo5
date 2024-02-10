using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordem_Servico.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrdemServicoID",
                table: "Tecnico");

            migrationBuilder.DropColumn(
                name: "OrdemServicoID",
                table: "Cliente");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Tecnico",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Tecnico",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Tecnico",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Servico",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Servico",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Servico",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Peca",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Peca",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Peca",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Peca",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "OrdemServico",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "OrdemServico",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "OrdemServico",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Ocorrencia",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Ocorrencia",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Ocorrencia",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Finalizacao",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Finalizacao",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Finalizacao",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Equipamento",
                keyColumn: "Modelo",
                keyValue: null,
                column: "Modelo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Equipamento",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Equipamento",
                keyColumn: "Marca",
                keyValue: null,
                column: "Marca",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Equipamento",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Equipamento",
                keyColumn: "DadosAdicionais",
                keyValue: null,
                column: "DadosAdicionais",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "DadosAdicionais",
                table: "Equipamento",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Equipamento",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Equipamento",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Equipamento",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Cliente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Cliente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Cliente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Cliente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Cliente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Cliente",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Cliente",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Cliente",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tecnico");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tecnico");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tecnico");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Peca");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Peca");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Peca");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Finalizacao");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Finalizacao");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Finalizacao");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "OrdemServicoID",
                table: "Tecnico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Peca",
                keyColumn: "Tipo",
                keyValue: null,
                column: "Tipo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Peca",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Equipamento",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Equipamento",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DadosAdicionais",
                table: "Equipamento",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "Telefone",
                keyValue: null,
                column: "Telefone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Cliente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "Endereco",
                keyValue: null,
                column: "Endereco",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Cliente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Cliente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "CPF",
                keyValue: null,
                column: "CPF",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Cliente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "CNPJ",
                keyValue: null,
                column: "CNPJ",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Cliente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "OrdemServicoID",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
