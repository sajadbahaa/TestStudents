using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTLayer.Migrations
{
    /// <inheritdoc />
    public partial class getinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "people",
            //    columns: table => new
            //    {
            //        PersonID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        firstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        secondName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        lastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        email = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
            //        phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
            //        birth = table.Column<DateOnly>(type: "date", nullable: false),
            //        gendor = table.Column<byte>(type: "TINYINT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_people", x => x.PersonID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "specilzeations",
            //    columns: table => new
            //    {
            //        specilizeId = table.Column<short>(type: "smallint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        specilizeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_specilzeations", x => x.specilizeId);
            //    });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    StudnetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.StudnetID);
                    table.ForeignKey(
                        name: "FK_students_people_PersonID",
                        column: x => x.PersonID,
                        principalTable: "people",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "items",
            //    columns: table => new
            //    {
            //        itemID = table.Column<short>(type: "smallint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        itemName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        specilizeID = table.Column<short>(type: "smallint", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_items", x => x.itemID);
            //        table.ForeignKey(
            //            name: "FK_items_specilzeations_specilizeID",
            //            column: x => x.specilizeID,
            //            principalTable: "specilzeations",
            //            principalColumn: "specilizeId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Teachers",
            //    columns: table => new
            //    {
            //        TeacherID = table.Column<short>(type: "smallint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        personID = table.Column<int>(type: "int", nullable: false),
            //        hireDate = table.Column<DateOnly>(type: "Date", nullable: false),
            //        specilzeID = table.Column<short>(type: "smallint", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Teachers", x => x.TeacherID);
            //        table.ForeignKey(
            //            name: "FK_Teachers_people_personID",
            //            column: x => x.personID,
            //            principalTable: "people",
            //            principalColumn: "PersonID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Teachers_specilzeations_specilzeID",
            //            column: x => x.specilzeID,
            //            principalTable: "specilzeations",
            //            principalColumn: "specilizeId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "enrollments",
                columns: table => new
                {
                    enrollID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudnetID = table.Column<int>(type: "int", nullable: false),
                    enrollDate = table.Column<DateOnly>(type: "date", nullable: false),
                    enrollStatus = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => x.enrollID);
                    table.ForeignKey(
                        name: "FK_enrollments_students_StudnetID",
                        column: x => x.StudnetID,
                        principalTable: "students",
                        principalColumn: "StudnetID");
                });

            //migrationBuilder.CreateTable(
            //    name: "courses",
            //    columns: table => new
            //    {
            //        courseID = table.Column<short>(type: "smallint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        itemID = table.Column<short>(type: "smallint", nullable: false),
            //        CreateAt = table.Column<DateOnly>(type: "Date", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        level = table.Column<byte>(type: "TINYINT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_courses", x => x.courseID);
            //        table.ForeignKey(
            //            name: "FK_courses_items_itemID",
            //            column: x => x.itemID,
            //            principalTable: "items",
            //            principalColumn: "itemID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TeacherCourses",
            //    columns: table => new
            //    {
            //        TeacherCourseID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        teacherID = table.Column<short>(type: "smallint", nullable: false),
            //        courseID = table.Column<short>(type: "smallint", nullable: false),
            //        startDate = table.Column<DateOnly>(type: "Date", nullable: false),
            //        endDate = table.Column<DateOnly>(type: "Date", nullable: false),
            //        note = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TeacherCourses", x => x.TeacherCourseID);
            //        table.ForeignKey(
            //            name: "FK_TeacherCourses_Teachers_teacherID",
            //            column: x => x.teacherID,
            //            principalTable: "Teachers",
            //            principalColumn: "TeacherID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_TeacherCourses_courses_courseID",
            //            column: x => x.courseID,
            //            principalTable: "courses",
            //            principalColumn: "courseID");
            //    });

            migrationBuilder.CreateTable(
                name: "enrollmentDetials",
                columns: table => new
                {
                    enrollDetialsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enrollID = table.Column<int>(type: "int", nullable: false),
                    TeacherCourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollmentDetials", x => x.enrollDetialsID);
                    table.ForeignKey(
                        name: "FK_enrollmentDetials_TeacherCourses_TeacherCourseID",
                        column: x => x.TeacherCourseID,
                        principalTable: "TeacherCourses",
                        principalColumn: "TeacherCourseID");
                    table.ForeignKey(
                        name: "FK_enrollmentDetials_enrollments_enrollID",
                        column: x => x.enrollID,
                        principalTable: "enrollments",
                        principalColumn: "enrollID",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_courses_itemID",
            //    table: "courses",
            //    column: "itemID",
            //    unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_enrollmentDetials_enrollID",
                table: "enrollmentDetials",
                column: "enrollID");

            migrationBuilder.CreateIndex(
                name: "IX_enrollmentDetials_TeacherCourseID",
                table: "enrollmentDetials",
                column: "TeacherCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_StudnetID",
                table: "enrollments",
                column: "StudnetID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_items_specilizeID",
            //    table: "items",
            //    column: "specilizeID");

            migrationBuilder.CreateIndex(
                name: "IX_students_PersonID",
                table: "students",
                column: "PersonID",
                unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_TeacherCourses_courseID",
            //    table: "TeacherCourses",
            //    column: "courseID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TeacherCourses_teacherID_courseID",
            //    table: "TeacherCourses",
            //    columns: new[] { "teacherID", "courseID" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Teachers_personID",
            //    table: "Teachers",
            //    column: "personID",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Teachers_specilzeID",
            //    table: "Teachers",
            //    column: "specilzeID");
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrollmentDetials");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "specilzeations");
        }
    }
}
