using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KPI.SportStuffInternetShop.Data.Migrations
{
    public partial class Produc8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId1",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId1",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_RoleId1",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserId1",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "Identity",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserId",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                schema: "Identity",
                table: "UserRole",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                schema: "Identity",
                table: "UserRole",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId1",
                schema: "Identity",
                table: "UserRole",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId1",
                schema: "Identity",
                table: "UserRole",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId1",
                schema: "Identity",
                table: "UserRole",
                column: "RoleId1",
                principalSchema: "Identity",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId1",
                schema: "Identity",
                table: "UserRole",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
