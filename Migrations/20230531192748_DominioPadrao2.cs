using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasFinancas.Migrations
{
    /// <inheritdoc />
    public partial class DominioPadrao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CriadoPor",
                table: "Usuario",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UltimaAtualizaPor",
                table: "Usuario",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Usuario",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioId",
                table: "Usuario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Usuario_UsuarioId",
                table: "Usuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Usuario_UsuarioId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_UsuarioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizaPor",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuario");
        }
    }
}
