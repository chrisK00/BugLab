using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "757b2158-40c3-4917-9523-5861973a4d2e", 0, "a7c0506c-d414-4132-83e2-4e39635e21b6", "chris@gmail.com", false, false, null, "CHRIS@GMAIL.COM", "CHRIS@GMAIL.COM", "AQAAAAEAACcQAAAAECubHHakqqtrEPwAkm4u8JVOjnKcQtg9Z1+jsPbzbhushIKHqJZhr2rAqmOcqczEvw==", null, false, "40b30d42-6b5b-43b3-8827-86e563d97ab7", false, "chris@gmail.com" },
                    { "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", 0, "d84a70f4-f849-4a98-a871-63f3683ecaa0", "chrisk@gmail.com", false, false, null, "CHRISK@GMAIL.COM", "CHRISK@GMAIL.COM", "AQAAAAEAACcQAAAAEPnq9OviTZIHvhd7TbV6E2yD9SLur2/DNLE1V0EAyL1AFQB0FWfNXJybWv83wqqVzA==", null, false, "f6886cd2-0824-485b-ae38-c5c3c44dc8f0", false, "chrisk@gmail.com" }
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
                table: "BugTypes",
                columns: new[] { "Id", "Color", "ProjectId", "Title" },
                values: new object[,]
                {
                    { 1, "#977FE4", 1, "refactor" },
                    { 2, "#b14639ff", 1, "bug" },
                    { 3, "#35ceceff", 1, "feature" },
                    { 4, "#35ceceff", 2, "feature" },
                    { 5, "#b14639ff", 2, "bug" },
                    { 6, "#977FE4", 2, "refactor" }
                });

            migrationBuilder.InsertData(
                table: "ProjectUsers",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { 1, "757b2158-40c3-4917-9523-5861973a4d2e" },
                    { 2, "757b2158-40c3-4917-9523-5861973a4d2e" },
                    { 3, "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62" }
                });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "AssignedToId", "BugTypeId", "Created", "CreatedById", "Deleted", "DeletedById", "Description", "Modified", "ModifiedById", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 2, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, "Better domaine events pattern", null, null, "None", 1, "Open", "update project title" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "AssignedToId", "BugTypeId", "Created", "CreatedById", "Deleted", "DeletedById", "Description", "Modified", "ModifiedById", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 3, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", null, null, null, null, null, "None", 2, "Open", "How you doing?" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "AssignedToId", "BugTypeId", "Created", "CreatedById", "Deleted", "DeletedById", "Description", "Modified", "ModifiedById", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 1, null, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, null, null, null, "None", 1, "Open", "Implement project controllers" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Deleted", "DeletedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 3, 2, new DateTime(2021, 11, 26, 18, 1, 45, 272, DateTimeKind.Utc).AddTicks(4938), "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", null, null, null, null, "Any progress?" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Deleted", "DeletedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 26, 18, 1, 45, 272, DateTimeKind.Utc).AddTicks(4356), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, null, null, "This has been implemented" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Deleted", "DeletedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 2, 1, new DateTime(2021, 11, 26, 18, 1, 45, 272, DateTimeKind.Utc).AddTicks(4935), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, null, null, "Nope" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 6);

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
                table: "ProjectUsers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 1, "757b2158-40c3-4917-9523-5861973a4d2e" });

            migrationBuilder.DeleteData(
                table: "ProjectUsers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 2, "757b2158-40c3-4917-9523-5861973a4d2e" });

            migrationBuilder.DeleteData(
                table: "ProjectUsers",
                keyColumns: new[] { "ProjectId", "UserId" },
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
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
