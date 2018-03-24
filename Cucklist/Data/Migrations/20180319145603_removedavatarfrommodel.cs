using Microsoft.EntityFrameworkCore.Migrations;

namespace Cucklist.Data.Migrations
{
    public partial class removedavatarfrommodel :Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.DropColumn(
            name: "AvatarImage",
            table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.AddColumn<byte[]>(
            name: "AvatarImage",
            table: "AspNetUsers",
            nullable: true);
        }
    }
}
