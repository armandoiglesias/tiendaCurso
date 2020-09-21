using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaService.Api.Author.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorEducationDegree",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EducationDegreeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SchoolName = table.Column<string>(nullable: true),
                    GraduationDate = table.Column<DateTime>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                    AuthorLibroId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorEducationDegree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorEducationDegree_Author_AuthorLibroId",
                        column: x => x.AuthorLibroId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorEducationDegree_AuthorLibroId",
                table: "AuthorEducationDegree",
                column: "AuthorLibroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorEducationDegree");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
