using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasFinancas.Migrations
{
    /// <inheritdoc />
    public partial class DominioPadrao3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Usuario_UsuarioId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_UsuarioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizaPor",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CriadoPor",
                table: "Usuario",
                column: "CriadoPor");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Usuario_CriadoPor",
                table: "Usuario",
                column: "CriadoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Usuario_CriadoPor",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_CriadoPor",
                table: "Usuario");

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
    }
}
