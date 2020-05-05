using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dimsum.Shaomai.Infrastructure.Migrations
{
    public partial class _2020050401 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "manager_user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RowVersion = table.Column<DateTime>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
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

            migrationBuilder.CreateTable(
                name: "solution",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RowVersion = table.Column<DateTime>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Name = table.Column<string>(nullable: true),
                    CName = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ManagerUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_solution_manager_user_ManagerUserId",
                        column: x => x.ManagerUserId,
                        principalTable: "manager_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "solution_env",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RowVersion = table.Column<DateTime>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    SolutionId = table.Column<Guid>(nullable: false),
                    EnvName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solution_env", x => x.Id);
                    table.ForeignKey(
                        name: "FK_solution_env_solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "solution_process",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RowVersion = table.Column<DateTime>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    SolutionId = table.Column<Guid>(nullable: false),
                    Level = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solution_process", x => x.Id);
                    table.ForeignKey(
                        name: "FK_solution_process_solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "solution_project",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RowVersion = table.Column<DateTime>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    SolutionId = table.Column<Guid>(nullable: false),
                    SolutionEnvId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CName = table.Column<string>(nullable: true),
                    AppId = table.Column<string>(nullable: true),
                    IsEnableWebHook = table.Column<bool>(nullable: false),
                    WebHookUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solution_project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_solution_project_solution_env_SolutionEnvId",
                        column: x => x.SolutionEnvId,
                        principalTable: "solution_env",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_solution_project_solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_manager_user_UserName_IsDeleted",
                table: "manager_user",
                columns: new[] { "UserName", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_solution_ManagerUserId",
                table: "solution",
                column: "ManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_solution_Name_IsDeleted",
                table: "solution",
                columns: new[] { "Name", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_solution_env_SolutionId_EnvName",
                table: "solution_env",
                columns: new[] { "SolutionId", "EnvName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_solution_process_SolutionId",
                table: "solution_process",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_solution_project_SolutionEnvId",
                table: "solution_project",
                column: "SolutionEnvId");

            migrationBuilder.CreateIndex(
                name: "IX_solution_project_SolutionId",
                table: "solution_project",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_solution_project_Name_SolutionId_IsDeleted",
                table: "solution_project",
                columns: new[] { "Name", "SolutionId", "IsDeleted" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "solution_process");

            migrationBuilder.DropTable(
                name: "solution_project");

            migrationBuilder.DropTable(
                name: "solution_env");

            migrationBuilder.DropTable(
                name: "solution");

            migrationBuilder.DropTable(
                name: "manager_user");
        }
    }
}
