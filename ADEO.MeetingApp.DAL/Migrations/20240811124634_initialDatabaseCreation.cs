using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ADEO.MeetingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initialDatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetingDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    FromTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ToTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComapnyLogoFileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    DidAttend = table.Column<bool>(type: "bit", nullable: false),
                    IsCalled = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attendees_MeetingDetails_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "MeetingDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    AttendeeID = table.Column<int>(type: "int", nullable: false),
                    CalledOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallEndedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CallHistory_Attendees_AttendeeID",
                        column: x => x.AttendeeID,
                        principalTable: "Attendees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MeetingDetails",
                columns: new[] { "ID", "ComapnyLogoFileName", "CompanyName", "Date", "FromTime", "HostContact", "HostFullName", "Name", "RoomName", "ToTime" },
                values: new object[,]
                {
                    { 1, "DU.png", "DU", new DateOnly(2024, 8, 11), new TimeOnly(9, 0, 0), "5051", "Mohamed Shaikh", "DU Product Launch", "#1 IT Room", new TimeOnly(10, 0, 0) },
                    { 2, "Etisalat.png", "Etisalat", new DateOnly(2024, 8, 11), new TimeOnly(11, 0, 0), "5150", "Yasir Shaikh", "Etisalat Product Launch", "#5 Projector Room ", new TimeOnly(12, 0, 0) },
                    { 3, "ABC.png", "ABC", new DateOnly(2024, 8, 11), new TimeOnly(14, 0, 0), "5012", "Govinda Siddartha", "ABC Annual Review", "#7 Conference", new TimeOnly(16, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_MeetingID",
                table: "Attendees",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_CallHistory_AttendeeID",
                table: "CallHistory",
                column: "AttendeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallHistory");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "MeetingDetails");
        }
    }
}
