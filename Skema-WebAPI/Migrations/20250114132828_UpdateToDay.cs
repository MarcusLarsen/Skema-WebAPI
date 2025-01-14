using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skema_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Day",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Day");
        }
    }
}
