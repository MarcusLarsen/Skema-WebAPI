using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skema_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Subject_SubjectId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Day_Teachers_TeacherId",
                table: "Day");

            migrationBuilder.DropIndex(
                name: "IX_Day_SubjectId",
                table: "Day");

            migrationBuilder.DropIndex(
                name: "IX_Day_TeacherId",
                table: "Day");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Day");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Day");

            migrationBuilder.CreateTable(
                name: "DaySubjects",
                columns: table => new
                {
                    DaySubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaySubjects", x => x.DaySubjectId);
                    table.ForeignKey(
                        name: "FK_DaySubjects_Day_DayId",
                        column: x => x.DayId,
                        principalTable: "Day",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaySubjects_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayTeachers",
                columns: table => new
                {
                    DayTeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTeachers", x => x.DayTeacherId);
                    table.ForeignKey(
                        name: "FK_DayTeachers_Day_DayId",
                        column: x => x.DayId,
                        principalTable: "Day",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaySubjects_DayId",
                table: "DaySubjects",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_DaySubjects_SubjectId",
                table: "DaySubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DayTeachers_DayId",
                table: "DayTeachers",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_DayTeachers_TeacherId",
                table: "DayTeachers",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaySubjects");

            migrationBuilder.DropTable(
                name: "DayTeachers");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Day",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Day",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Day_SubjectId",
                table: "Day",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_TeacherId",
                table: "Day",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Subject_SubjectId",
                table: "Day",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Teachers_TeacherId",
                table: "Day",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
