using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBApi.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeToComplete",
                table: "Trainings");

            migrationBuilder.AddColumn<int>(
                name: "TimeToComplete",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Times",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeToComplete",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Times",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "TimeToComplete",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
