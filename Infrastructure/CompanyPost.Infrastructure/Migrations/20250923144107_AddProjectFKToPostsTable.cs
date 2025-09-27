using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectFKToPostsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "project_id",
                table: "posts",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "ix_posts_project_id",
                table: "posts",
                column: "project_id");

            migrationBuilder.AddForeignKey(
                name: "fk_posts_projects_project_id",
                table: "posts",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_posts_projects_project_id",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "ix_posts_project_id",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "project_id",
                table: "posts");
        }
    }
}
