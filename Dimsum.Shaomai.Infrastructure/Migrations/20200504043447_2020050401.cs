using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dimsum.Shaomai.Infrastructure.Migrations
{
    public partial class _2020050401 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "solution",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CName = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solution", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_solution_Name_IsDeleted",
                table: "solution",
                columns: new[] { "Name", "IsDeleted" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "solution");
        }
    }
}
