using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Quiz.DAL.Migrations
{
    public partial class Addnewtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUserquiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Surname = table.Column<string>(maxLength: 150, nullable: false),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserquiz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSessionquiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    Begin = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Marks = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSessionquiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblSessionquiz_tblUserquiz_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUserquiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblResultquiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblResultquiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblResultquiz_tblAnswer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "tblAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblResultquiz_tblSessionquiz_SessionId",
                        column: x => x.SessionId,
                        principalTable: "tblSessionquiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblResultquiz_AnswerId",
                table: "tblResultquiz",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblResultquiz_SessionId",
                table: "tblResultquiz",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSessionquiz_UserId",
                table: "tblSessionquiz",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblResultquiz");

            migrationBuilder.DropTable(
                name: "tblSessionquiz");

            migrationBuilder.DropTable(
                name: "tblUserquiz");
        }
    }
}
