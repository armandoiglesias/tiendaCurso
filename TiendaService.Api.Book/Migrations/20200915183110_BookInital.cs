using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaService.Api.Book.Migrations
{
    public partial class BookInital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PublishedDate = table.Column<DateTime>(nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
