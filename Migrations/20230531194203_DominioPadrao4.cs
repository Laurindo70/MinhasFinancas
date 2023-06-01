using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasFinancas.Migrations
{
    /// <inheritdoc />
    public partial class DominioPadrao4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UltimaAtualizacaoPor",
                table: "Usuario",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UltimaAtualizacaoPor",
                table: "Usuario",
                column: "UltimaAtualizacaoPor");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Usuario_UltimaAtualizacaoPor",
                table: "Usuario",
                column: "UltimaAtualizacaoPor",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Usuario_UltimaAtualizacaoPor",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_UltimaAtualizacaoPor",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacaoPor",
                table: "Usuario");
        }
    }
}
