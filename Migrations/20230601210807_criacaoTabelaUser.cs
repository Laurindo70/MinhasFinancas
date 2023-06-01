using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasFinancas.Migrations
{
    /// <inheritdoc />
    public partial class criacaoTabelaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Activated_by_email = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Account_activated = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    User_created = table.Column<Guid>(type: "uuid", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    User_updated = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_User_created",
                        column: x => x.User_created,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_User_User_updated",
                        column: x => x.User_updated,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_User_created",
                table: "User",
                column: "User_created");

            migrationBuilder.CreateIndex(
                name: "IX_User_User_updated",
                table: "User",
                column: "User_updated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
