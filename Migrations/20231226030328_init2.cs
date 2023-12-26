using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace campapi.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WasPasswordResetRequest",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TokenValidBefore",
                table: "Users",
                newName: "YearOfInitiation");

            migrationBuilder.RenameColumn(
                name: "RestoreCodeValidBefore",
                table: "Users",
                newName: "HeldPost");

            migrationBuilder.RenameColumn(
                name: "RestoreCode",
                table: "Users",
                newName: "Headquarters");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Detachment",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detachment",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "YearOfInitiation",
                table: "Users",
                newName: "TokenValidBefore");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "HeldPost",
                table: "Users",
                newName: "RestoreCodeValidBefore");

            migrationBuilder.RenameColumn(
                name: "Headquarters",
                table: "Users",
                newName: "RestoreCode");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "WasPasswordResetRequest",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
