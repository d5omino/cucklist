using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cucklist.Data.Migrations
{
    public partial class pingademulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_ImageOwnerId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_AspNetUsers_OwnerId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Image",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Image",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "ImageOwnerId",
                table: "Image",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Image_ImageOwnerId",
                table: "Image",
                newName: "IX_Image_OwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Video",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_OwnerId",
                table: "Image",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_AspNetUsers_OwnerId",
                table: "Video",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_OwnerId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_AspNetUsers_OwnerId",
                table: "Video");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Image",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Image",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Image",
                newName: "ImageOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Image_OwnerId",
                table: "Image",
                newName: "IX_Image_ImageOwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Video",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Video",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Image",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_ImageOwnerId",
                table: "Image",
                column: "ImageOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_AspNetUsers_OwnerId",
                table: "Video",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
