using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cucklist.Data.Migrations
{
    public partial class changedstuffagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SexualIdentity",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "BiologicalSex",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sexuality",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiologicalSex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sexuality",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SexualIdentity",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
