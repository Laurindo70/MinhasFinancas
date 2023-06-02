using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasFinancas.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoTabelaContasAoContexto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Available_value = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    Amount_received_per_month = table.Column<double>(type: "double precision", nullable: false),
                    Value_credit = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    Responsible_user = table.Column<Guid>(type: "uuid", nullable: true),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    User_created = table.Column<Guid>(type: "uuid", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    User_updated = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_User_Responsible_user",
                        column: x => x.Responsible_user,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Account_User_User_created",
                        column: x => x.User_created,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Account_User_User_updated",
                        column: x => x.User_updated,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Responsible_user",
                table: "Account",
                column: "Responsible_user");

            migrationBuilder.CreateIndex(
                name: "IX_Account_User_created",
                table: "Account",
                column: "User_created");

            migrationBuilder.CreateIndex(
                name: "IX_Account_User_updated",
                table: "Account",
                column: "User_updated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
