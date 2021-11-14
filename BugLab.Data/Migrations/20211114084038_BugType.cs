using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class BugType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IdentityUserProject",
                keyColumns: new[] { "ProjectsId", "UsersId" },
                keyValues: new object[] { 1, "757b2158-40c3-4917-9523-5861973a4d2e" });

            migrationBuilder.DeleteData(
                table: "IdentityUserProject",
                keyColumns: new[] { "ProjectsId", "UsersId" },
                keyValues: new object[] { 2, "757b2158-40c3-4917-9523-5861973a4d2e" });

            migrationBuilder.DeleteData(
                table: "IdentityUserProject",
                keyColumns: new[] { "ProjectsId", "UsersId" },
                keyValues: new object[] { 3, "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62");

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "BugTypeId",
                table: "Bugs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BugTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugTypes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_BugTypeId",
                table: "Bugs",
                column: "BugTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTypes_ProjectId",
                table: "BugTypes",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_BugTypes_BugTypeId",
                table: "Bugs",
                column: "BugTypeId",
                principalTable: "BugTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_BugTypes_BugTypeId",
                table: "Bugs");

            migrationBuilder.DropTable(
                name: "BugTypes");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_BugTypeId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "BugTypeId",
                table: "Bugs");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "757b2158-40c3-4917-9523-5861973a4d2e", 0, "a1b0ac80-ac8f-4a1f-8fda-a6f2c0ccefb6", "chris@gmail.com", false, false, null, "CHRIS@GMAIL.COM", "CHRIS@GMAIL.COM", "AQAAAAEAACcQAAAAEIsTfCpD016p5SAFCKHIl+nf4oeIZsOaf8+HOO12UdQPNsF5sSb4iCB9xd/03bFzTg==", null, false, "0479686f-5a0c-4f52-9004-283bcdfd2456", false, "chris@gmail.com" },
                    { "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", 0, "4724509b-3139-4d3f-9c78-9f7b0480ca19", "chrisk@gmail.com", false, false, null, "CHRISK@GMAIL.COM", "CHRISK@GMAIL.COM", "AQAAAAEAACcQAAAAECVWSnKQOpsPjkMkgLk0nD+35qTEVbU0w3OBxO93K3RWFpI9aKYCxbXYx9v1vFfjpg==", null, false, "0c2e1284-2da2-43ed-80fd-e0a6a35cd078", false, "chrisk@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, null, "BugLab" },
                    { 2, null, "Plannial" },
                    { 3, null, "SweatSpace" }
                });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "Created", "CreatedById", "Description", "Modified", "ModifiedById", "Priority", "ProjectId", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, null, "None", 1, "Open", "Implement project controllers" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "757b2158-40c3-4917-9523-5861973a4d2e", "Better domaine events pattern", null, null, "None", 1, "Open", "update project title" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", null, null, null, "None", 2, "Open", "How you doing?" }
                });

            migrationBuilder.InsertData(
                table: "IdentityUserProject",
                columns: new[] { "ProjectsId", "UsersId" },
                values: new object[,]
                {
                    { 1, "757b2158-40c3-4917-9523-5861973a4d2e" },
                    { 2, "757b2158-40c3-4917-9523-5861973a4d2e" },
                    { 3, "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 12, 15, 59, 51, 525, DateTimeKind.Utc).AddTicks(4846), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, "This has been implemented" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 2, 1, new DateTime(2021, 11, 12, 15, 59, 51, 525, DateTimeKind.Utc).AddTicks(5469), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, "Nope" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 3, 2, new DateTime(2021, 11, 12, 15, 59, 51, 525, DateTimeKind.Utc).AddTicks(5472), "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", null, null, "Any progress?" });
        }
    }
}
