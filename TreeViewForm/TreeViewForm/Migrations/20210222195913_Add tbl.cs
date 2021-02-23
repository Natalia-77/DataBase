using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeViewForm.Migrations
{
    public partial class Addtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlSlug",
                table: "Cosmetic",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlSlug",
                table: "Cosmetic");
        }
    }
}
