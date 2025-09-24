using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTLayer.Migrations
{
    /// <inheritdoc />
    public partial class addteacherCoursesentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherCourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherID = table.Column<short>(type: "smallint", nullable: false),
                    courseID = table.Column<short>(type: "smallint", nullable: false),
                    startDate = table.Column<DateOnly>(type: "Date", nullable: false),
                    endDate = table.Column<DateOnly>(type: "Date", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.TeacherCourseID);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_teacherID",
                        column: x => x.teacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_courses_courseID",
                        column: x => x.courseID,
                        principalTable: "courses",
                        principalColumn: "courseID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_courseID",
                table: "TeacherCourses",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_teacherID",
                table: "TeacherCourses",
                column: "teacherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherCourses");
        }
    }
}
