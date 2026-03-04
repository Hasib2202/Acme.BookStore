using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Added_CategoryId_To_Book : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "AppBooks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppBooks_CategoryId",
                table: "AppBooks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBooks_AppCategories_CategoryId",
                table: "AppBooks",
                column: "CategoryId",
                principalTable: "AppCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBooks_AppCategories_CategoryId",
                table: "AppBooks");

            migrationBuilder.DropIndex(
                name: "IX_AppBooks_CategoryId",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AppBooks");
        }
    }
}
