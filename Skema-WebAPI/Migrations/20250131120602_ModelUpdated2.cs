using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skema_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourse_Course_CourseId",
                table: "TeacherCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourse_Teachers_TeacherId",
                table: "TeacherCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherCourse",
                table: "TeacherCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "TeacherCourse",
                newName: "TeachersCourse");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourse_TeacherId",
                table: "TeachersCourse",
                newName: "IX_TeachersCourse_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourse_CourseId",
                table: "TeachersCourse",
                newName: "IX_TeachersCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeachersCourse",
                table: "TeachersCourse",
                column: "TeacherCourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersCourse_Courses_CourseId",
                table: "TeachersCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersCourse_Teachers_TeacherId",
                table: "TeachersCourse",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeachersCourse_Courses_CourseId",
                table: "TeachersCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersCourse_Teachers_TeacherId",
                table: "TeachersCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeachersCourse",
                table: "TeachersCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "TeachersCourse",
                newName: "TeacherCourse");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_TeachersCourse_TeacherId",
                table: "TeacherCourse",
                newName: "IX_TeacherCourse_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeachersCourse_CourseId",
                table: "TeacherCourse",
                newName: "IX_TeacherCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherCourse",
                table: "TeacherCourse",
                column: "TeacherCourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourse_Course_CourseId",
                table: "TeacherCourse",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourse_Teachers_TeacherId",
                table: "TeacherCourse",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
