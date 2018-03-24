using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cucklist.Data.Migrations
{
    public partial class newstufftofixoldstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_ApplicationUserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ApplicationUserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "PathToImage",
                table: "Images",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Images",
                newName: "OwnwerId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnwerId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_OwnwerId",
                table: "Images",
                column: "OwnwerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_OwnwerId",
                table: "Images",
                column: "OwnwerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_OwnwerId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_OwnwerId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "OwnwerId",
                table: "Images",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Images",
                newName: "PathToImage");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Images",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ImageData",
                table: "Images",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ApplicationUserId",
                table: "Images",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_ApplicationUserId",
                table: "Images",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
