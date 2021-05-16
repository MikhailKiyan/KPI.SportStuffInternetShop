using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KPI.SportStuffInternetShop.Data.Migrations
{
    public partial class Produc9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToken_User_UserId1",
                schema: "Identity",
                table: "UserToken");

            migrationBuilder.DropIndex(
                name: "IX_UserToken_UserId1",
                schema: "Identity",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "UserToken");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                schema: "Identity",
                table: "UserToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserToken_UserId",
                schema: "Identity",
                table: "UserToken");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                schema: "Identity",
                table: "UserToken",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId1",
                schema: "Identity",
                table: "UserToken",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToken_User_UserId1",
                schema: "Identity",
                table: "UserToken",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
