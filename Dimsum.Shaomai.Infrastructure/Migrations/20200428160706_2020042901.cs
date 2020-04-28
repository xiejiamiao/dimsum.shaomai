using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dimsum.Shaomai.Infrastructure.Migrations
{
    public partial class _2020042901 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "manager_user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailIsValidate = table.Column<bool>(nullable: false),
                    AvatarUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manager_user", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_manager_user_UserName_IsDeleted",
                table: "manager_user",
                columns: new[] { "UserName", "IsDeleted" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manager_user");
        }
    }
}
