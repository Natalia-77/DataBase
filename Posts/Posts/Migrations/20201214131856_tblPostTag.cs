using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Posts.Migrations
{
    public partial class tblPostTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPostTag",
                table: "tblPostTag");

            migrationBuilder.DropIndex(
                name: "IX_tblPostTag_PostId",
                table: "tblPostTag");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tblPostTag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPostTag",
                table: "tblPostTag",
                columns: new[] { "PostId", "TagId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPostTag",
                table: "tblPostTag");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tblPostTag",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPostTag",
                table: "tblPostTag",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPostTag_PostId",
                table: "tblPostTag",
                column: "PostId");
        }
    }
}
