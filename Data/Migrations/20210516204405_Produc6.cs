using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KPI.SportStuffInternetShop.Data.Migrations
{
    public partial class Produc6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaim_User_UserId1",
                schema: "Identity",
                table: "UserClaim");

            migrationBuilder.DropIndex(
                name: "IX_UserClaim_UserId1",
                schema: "Identity",
                table: "UserClaim");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "UserClaim");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                schema: "Identity",
                table: "UserClaim",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId1",
                schema: "Identity",
                table: "UserClaim",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaim_User_UserId1",
                schema: "Identity",
                table: "UserClaim",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
