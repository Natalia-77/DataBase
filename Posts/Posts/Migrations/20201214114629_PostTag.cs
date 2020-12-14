using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Posts.Migrations
{
    public partial class PostTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTag_tblPost_PostId",
                table: "tblTag");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "tblTag",
                newName: "PostTagId");

            migrationBuilder.RenameIndex(
                name: "IX_tblTag_PostId",
                table: "tblTag",
                newName: "IX_tblTag_PostTagId");

            migrationBuilder.AddColumn<int>(
                name: "PostTagId",
                table: "tblPost",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblPostTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPostTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPostTag_tblPost_PostId",
                        column: x => x.PostId,
                        principalTable: "tblPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPostTag_tblTag_TagId",
                        column: x => x.TagId,
                        principalTable: "tblTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPost_PostTagId",
                table: "tblPost",
                column: "PostTagId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPostTag_PostId",
                table: "tblPostTag",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPostTag_TagId",
                table: "tblPostTag",
                column: "TagId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblPost_tblPostTag_PostTagId",
                table: "tblPost");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTag_tblPostTag_PostTagId",
                table: "tblTag");

            migrationBuilder.DropTable(
                name: "tblPostTag");

            migrationBuilder.DropIndex(
                name: "IX_tblPost_PostTagId",
                table: "tblPost");

            migrationBuilder.DropColumn(
                name: "PostTagId",
                table: "tblPost");

            migrationBuilder.RenameColumn(
                name: "PostTagId",
                table: "tblTag",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_tblTag_PostTagId",
                table: "tblTag",
                newName: "IX_tblTag_PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTag_tblPost_PostId",
                table: "tblTag",
                column: "PostId",
                principalTable: "tblPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
