using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoFKForPostHeaderAndPostTypeInPostsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "post_header_id",
                table: "posts",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "post_type_id",
                table: "posts",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "ix_posts_post_header_id",
                table: "posts",
                column: "post_header_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_post_type_id",
                table: "posts",
                column: "post_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_posts_post_headers_post_header_id",
                table: "posts",
                column: "post_header_id",
                principalTable: "post_headers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_posts_post_types_post_type_id",
                table: "posts",
                column: "post_type_id",
                principalTable: "post_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_posts_post_headers_post_header_id",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "fk_posts_post_types_post_type_id",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "ix_posts_post_header_id",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "ix_posts_post_type_id",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "post_header_id",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "post_type_id",
                table: "posts");
        }
    }
}
