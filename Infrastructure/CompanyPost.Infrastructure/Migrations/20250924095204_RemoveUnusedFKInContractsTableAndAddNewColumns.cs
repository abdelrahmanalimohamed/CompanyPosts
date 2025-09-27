using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedFKInContractsTableAndAddNewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contracts_person_orgs_person_org_from_id",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "fk_contracts_person_orgs_person_org_prepared_by_id",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "date_of_delivery",
                table: "contracts");

            migrationBuilder.RenameColumn(
                name: "person_org_prepared_by_id",
                table: "contracts",
                newName: "person_org_id");

            migrationBuilder.RenameColumn(
                name: "person_org_from_id",
                table: "contracts",
                newName: "created_by_id");

            migrationBuilder.RenameIndex(
                name: "ix_contracts_person_org_prepared_by_id",
                table: "contracts",
                newName: "ix_contracts_person_org_id");

            migrationBuilder.RenameIndex(
                name: "ix_contracts_person_org_from_id",
                table: "contracts",
                newName: "ix_contracts_created_by_id");

            migrationBuilder.AddColumn<string>(
                name: "working",
                table: "contracts",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_person_orgs_person_org_id",
                table: "contracts",
                column: "person_org_id",
                principalTable: "person_orgs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_sys_users_created_by_id",
                table: "contracts",
                column: "created_by_id",
                principalTable: "sys_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contracts_person_orgs_person_org_id",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "fk_contracts_sys_users_created_by_id",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "working",
                table: "contracts");

            migrationBuilder.RenameColumn(
                name: "person_org_id",
                table: "contracts",
                newName: "person_org_prepared_by_id");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "contracts",
                newName: "person_org_from_id");

            migrationBuilder.RenameIndex(
                name: "ix_contracts_person_org_id",
                table: "contracts",
                newName: "ix_contracts_person_org_prepared_by_id");

            migrationBuilder.RenameIndex(
                name: "ix_contracts_created_by_id",
                table: "contracts",
                newName: "ix_contracts_person_org_from_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "date_of_delivery",
                table: "contracts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_person_orgs_person_org_from_id",
                table: "contracts",
                column: "person_org_from_id",
                principalTable: "person_orgs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_person_orgs_person_org_prepared_by_id",
                table: "contracts",
                column: "person_org_prepared_by_id",
                principalTable: "person_orgs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
