using Microsoft.EntityFrameworkCore.Migrations;

namespace Practice.Migrations
{
    public partial class Removequizidfromquestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quizId",
                table: "questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quizId",
                table: "questions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
