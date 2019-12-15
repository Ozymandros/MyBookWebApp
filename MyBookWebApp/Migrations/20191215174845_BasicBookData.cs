using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBookWebApp.Migrations
{
    public partial class BasicBookData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Books",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Books",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Books");
        }
    }
}
