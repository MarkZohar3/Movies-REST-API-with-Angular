using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Backend.Migrations
{
    public partial class addeddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Movies",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "id");
        }
    }
}
