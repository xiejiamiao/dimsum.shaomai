using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dimsum.Shaomai.Infrastructure.Migrations
{
    public partial class _2020050402 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ManagerUserId",
                table: "solution",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_solution_ManagerUserId",
                table: "solution",
                column: "ManagerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_solution_manager_user_ManagerUserId",
                table: "solution",
                column: "ManagerUserId",
                principalTable: "manager_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_solution_manager_user_ManagerUserId",
                table: "solution");

            migrationBuilder.DropIndex(
                name: "IX_solution_ManagerUserId",
                table: "solution");

            migrationBuilder.DropColumn(
                name: "ManagerUserId",
                table: "solution");
        }
    }
}
