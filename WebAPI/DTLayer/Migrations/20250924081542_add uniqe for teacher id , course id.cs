using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTLayer.Migrations
{
    /// <inheritdoc />
    public partial class adduniqeforteacheridcourseid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherCourses_teacherID",
                table: "TeacherCourses");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_teacherID_courseID",
                table: "TeacherCourses",
                columns: new[] { "teacherID", "courseID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherCourses_teacherID_courseID",
                table: "TeacherCourses");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_teacherID",
                table: "TeacherCourses",
                column: "teacherID");
        }
    }
}
