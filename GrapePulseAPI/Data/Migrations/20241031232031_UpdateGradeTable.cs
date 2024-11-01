using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradePulseAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGradeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GradeValue",
                table: "Grades",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeValue",
                table: "Grades");
        }
    }
}
