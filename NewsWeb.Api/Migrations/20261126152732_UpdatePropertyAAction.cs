using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsWeb.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertyAAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ArticleActions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ArticleActions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
