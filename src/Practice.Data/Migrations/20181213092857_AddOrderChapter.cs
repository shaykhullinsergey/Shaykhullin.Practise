using Microsoft.EntityFrameworkCore.Migrations;

namespace Practice.Migrations
{
    public partial class AddOrderChapter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order",
                table: "chapters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order",
                table: "chapters");
        }
    }
}
