using Microsoft.EntityFrameworkCore.Migrations;

namespace Practice.Migrations
{
    public partial class QuestionsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answers_quiestions_questionId",
                table: "answers");

            migrationBuilder.DropForeignKey(
                name: "FK_quiestions_lectures_LectureId",
                table: "quiestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_quiestions",
                table: "quiestions");

            migrationBuilder.RenameTable(
                name: "quiestions",
                newName: "questions");

            migrationBuilder.RenameIndex(
                name: "IX_quiestions_LectureId",
                table: "questions",
                newName: "IX_questions_LectureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_questions",
                table: "questions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_answers_questions_questionId",
                table: "answers",
                column: "questionId",
                principalTable: "questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_lectures_LectureId",
                table: "questions",
                column: "LectureId",
                principalTable: "lectures",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answers_questions_questionId",
                table: "answers");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_lectures_LectureId",
                table: "questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_questions",
                table: "questions");

            migrationBuilder.RenameTable(
                name: "questions",
                newName: "quiestions");

            migrationBuilder.RenameIndex(
                name: "IX_questions_LectureId",
                table: "quiestions",
                newName: "IX_quiestions_LectureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_quiestions",
                table: "quiestions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_answers_quiestions_questionId",
                table: "answers",
                column: "questionId",
                principalTable: "quiestions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quiestions_lectures_LectureId",
                table: "quiestions",
                column: "LectureId",
                principalTable: "lectures",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
