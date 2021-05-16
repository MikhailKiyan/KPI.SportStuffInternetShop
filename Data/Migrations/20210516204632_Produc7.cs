using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KPI.SportStuffInternetShop.Data.Migrations
{
    public partial class Produc7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_User_UserId1",
                schema: "Identity",
                table: "UserLogin");

            migrationBuilder.DropIndex(
                name: "IX_UserLogin_UserId1",
                schema: "Identity",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "UserLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                schema: "Identity",
                table: "UserLogin",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId1",
                schema: "Identity",
                table: "UserLogin",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_User_UserId1",
                schema: "Identity",
                table: "UserLogin",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
