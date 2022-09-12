using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBazaar.Migrations
{
    public partial class CommentDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentDate",
                table: "comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentDate",
                table: "comments");
        }
    }
}
