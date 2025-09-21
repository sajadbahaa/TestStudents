using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTLayer.Migrations
{
    /// <inheritdoc />
    public partial class addPeopleentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    secondName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    birth = table.Column<DateOnly>(type: "date", nullable: false),
                    gendor = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.PersonID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
