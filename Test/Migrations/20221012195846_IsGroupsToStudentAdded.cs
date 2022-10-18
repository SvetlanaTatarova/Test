using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class IsGroupsToStudentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Groups_AcademicGroupId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AcademicGroupId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AcademicGroupId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_StudentId",
                table: "Groups",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Students_StudentId",
                table: "Groups",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Students_StudentId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_StudentId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "AcademicGroupId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcademicGroupId",
                table: "Courses",
                column: "AcademicGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Groups_AcademicGroupId",
                table: "Courses",
                column: "AcademicGroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
