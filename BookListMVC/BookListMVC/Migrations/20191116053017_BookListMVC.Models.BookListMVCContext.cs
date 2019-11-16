using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookListMVC.Migrations
{
    public partial class BookListMVCModelsBookListMVCContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Genre", "Price", "PublishDate", "Title" },
                values: new object[] { 1, "Genre1", 20m, new DateTime(2012, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book1" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Genre", "Price", "PublishDate", "Title" },
                values: new object[] { 2, "Genre2", 30m, new DateTime(2008, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
