using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FilterShop.Migrations
{
    public partial class Addtblshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblFilterNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFilterNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFilterValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFilterValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFilterNameGroups",
                columns: table => new
                {
                    FilterNameId = table.Column<int>(nullable: false),
                    FilterValueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFilterNameGroups", x => new { x.FilterValueId, x.FilterNameId });
                    table.ForeignKey(
                        name: "FK_tblFilterNameGroups_tblFilterNames_FilterNameId",
                        column: x => x.FilterNameId,
                        principalTable: "tblFilterNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFilterNameGroups_tblFilterValues_FilterValueId",
                        column: x => x.FilterValueId,
                        principalTable: "tblFilterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblFilterNameGroups_FilterNameId",
                table: "tblFilterNameGroups",
                column: "FilterNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFilterNameGroups");

            migrationBuilder.DropTable(
                name: "tblFilterNames");

            migrationBuilder.DropTable(
                name: "tblFilterValues");
        }
    }
}
