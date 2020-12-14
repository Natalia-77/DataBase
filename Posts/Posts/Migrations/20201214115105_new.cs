using Microsoft.EntityFrameworkCore.Migrations;

namespace Posts.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblPost_tblPostTag_PostTagId",
                table: "tblPost");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTag_tblPostTag_PostTagId",
                table: "tblTag");

            migrationBuilder.DropIndex(
                name: "IX_tblTag_PostTagId",
                table: "tblTag");

            migrationBuilder.DropIndex(
                name: "IX_tblPost_PostTagId",
                table: "tblPost");

            migrationBuilder.DropColumn(
                name: "PostTagId",
                table: "tblTag");

            migrationBuilder.DropColumn(
                name: "PostTagId",
                table: "tblPost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostTagId",
                table: "tblTag",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostTagId",
                table: "tblPost",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblTag_PostTagId",
                table: "tblTag",
                column: "PostTagId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPost_PostTagId",
                table: "tblPost",
                column: "PostTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblPost_tblPostTag_PostTagId",
                table: "tblPost",
                column: "PostTagId",
                principalTable: "tblPostTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTag_tblPostTag_PostTagId",
                table: "tblTag",
                column: "PostTagId",
                principalTable: "tblPostTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
