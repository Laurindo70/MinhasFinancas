using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasFinancas.Migrations
{
    /// <inheritdoc />
    public partial class ajusteDeTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Activated_by_email = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Account_activated = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    User_created = table.Column<Guid>(type: "uuid", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    User_updated = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_User_created",
                        column: x => x.User_created,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_User_User_updated",
                        column: x => x.User_updated,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Available_value = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    Amount_received_per_month = table.Column<double>(type: "double precision", nullable: false),
                    Value_credit = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    Responsible_user = table.Column<Guid>(type: "uuid", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    User_created = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_User_User_created",
                        column: x => x.User_created,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_User_User_updated",
                        column: x => x.User_updated,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User_has_account",
                columns: table => new
                {
                    User_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Account_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_User_has_account_Account_Account_id",
                        column: x => x.Account_id,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_has_account_User_User_id",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_User_User_created",
                table: "User",
                column: "User_created");

            migrationBuilder.CreateIndex(
                name: "IX_User_User_updated",
                table: "User",
                column: "User_updated");

            migrationBuilder.CreateIndex(
                name: "IX_User_has_account_Account_id",
                table: "User_has_account",
                column: "Account_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_has_account_User_id",
                table: "User_has_account",
                column: "User_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_has_account");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
