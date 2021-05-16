using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KPI.SportStuffInternetShop.Data.Migrations
{
    public partial class Produc5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaim_Role_RoleId1",
                schema: "Identity",
                table: "RoleClaim");

            migrationBuilder.DropIndex(
                name: "IX_RoleClaim_RoleId1",
                schema: "Identity",
                table: "RoleClaim");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                schema: "Identity",
                table: "RoleClaim");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                schema: "Identity",
                table: "RoleClaim",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId1",
                schema: "Identity",
                table: "RoleClaim",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaim_Role_RoleId1",
                schema: "Identity",
                table: "RoleClaim",
                column: "RoleId1",
                principalSchema: "Identity",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
