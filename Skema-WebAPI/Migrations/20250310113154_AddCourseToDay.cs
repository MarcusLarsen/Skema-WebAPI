using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skema_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseToDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Day",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Day_CourseId",
                table: "Day",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Courses_CourseId",
                table: "Day",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Courses_CourseId",
                table: "Day");

            migrationBuilder.DropIndex(
                name: "IX_Day_CourseId",
                table: "Day");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Day");
        }
    }
}
