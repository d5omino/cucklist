using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cucklist.Data.Migrations
{
    public partial class changedstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CuckRole",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuckRole",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
