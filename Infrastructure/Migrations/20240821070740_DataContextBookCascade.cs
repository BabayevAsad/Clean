using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataContextBookCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_people_PersonId",
                table: "books");

            migrationBuilder.AddForeignKey(
                name: "FK_books_people_PersonId",
                table: "books",
                column: "PersonId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_people_PersonId",
                table: "books");

            migrationBuilder.AddForeignKey(
                name: "FK_books_people_PersonId",
                table: "books",
                column: "PersonId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
