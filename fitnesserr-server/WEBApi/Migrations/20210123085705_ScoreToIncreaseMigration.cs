using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBApi.Migrations
{
    public partial class ScoreToIncreaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoreToIncrease",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreToIncrease",
                table: "Exercises");
        }
    }
}
