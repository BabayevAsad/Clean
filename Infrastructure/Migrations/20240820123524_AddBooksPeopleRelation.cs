using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBooksPeopleRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_books_PersonId",
                table: "books",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_people_PersonId",
                table: "books",
                column: "PersonId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_people_PersonId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_PersonId",
                table: "books");
        }
    }
}
