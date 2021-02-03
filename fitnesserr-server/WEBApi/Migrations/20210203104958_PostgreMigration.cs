using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBApi.Migrations
{
    public partial class PostgreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    Type = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    Likes = table.Column<int>(type: "integer", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Password = table.Column<string>(type: "varchar(500)", nullable: false),
                    Email = table.Column<string>(type: "varchar(400)", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingId = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    TimeToComplete = table.Column<int>(type: "integer", nullable: false),
                    ScoreToIncrease = table.Column<int>(type: "integer", nullable: false),
                    Times = table.Column<int>(type: "integer", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateDone = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimeDone = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDone_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPrograms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDone_UserId",
                table: "TrainingDone",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_UserId",
                table: "TrainingPrograms",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "TrainingDone");

            migrationBuilder.DropTable(
                name: "TrainingPrograms");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
