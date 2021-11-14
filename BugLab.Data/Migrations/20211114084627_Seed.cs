using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "757b2158-40c3-4917-9523-5861973a4d2e", 0, "beb82d59-4b98-4d3b-9c0e-cd475ccdba10", "chris@gmail.com", false, false, null, "CHRIS@GMAIL.COM", "CHRIS@GMAIL.COM", "AQAAAAEAACcQAAAAECcG+lJQ1Dien7luSX3gTnDtyDi3ua0xJJm0wG4qSaIrEG9WG73KbCPrqQWnLX1BZw==", null, false, "a5c5d217-9520-460f-b64c-daa59b0f5d59", false, "chris@gmail.com" },
                    { "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", 0, "a9e22fa1-f9ea-4bcb-bcba-002550555fff", "chrisk@gmail.com", false, false, null, "CHRISK@GMAIL.COM", "CHRISK@GMAIL.COM", "AQAAAAEAACcQAAAAEJsCiMrS6VazQ3u39+xlXYr2Z+VzGvlWeTMRHJCsmn8sfxGYKi1BCMInR2Jyc+xnmQ==", null, false, "dc16f8af-d90e-483f-935a-6d076d15fe9c", false, "chrisk@gmail.com" }
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
                columns: new[] { "Id", "ProjectId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "refactor" },
                    { 2, 1, "bug" },
                    { 3, 1, "feature" },
                    { 4, 2, "feature" },
                    { 5, 2, "bug" },
                    { 6, 2, "refactor" }
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
                table: "Bugs",
                columns: new[] { "Id", "BugTypeId", "Created", "CreatedById", "Description", "Modified", "ModifiedById", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "757b2158-40c3-4917-9523-5861973a4d2e", "Better domaine events pattern", null, null, "None", 1, "Open", "update project title" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "BugTypeId", "Created", "CreatedById", "Description", "Modified", "ModifiedById", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", null, null, null, "None", 2, "Open", "How you doing?" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "BugTypeId", "Created", "CreatedById", "Description", "Modified", "ModifiedById", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, null, "None", 1, "Open", "Implement project controllers" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 3, 2, new DateTime(2021, 11, 14, 8, 46, 26, 794, DateTimeKind.Utc).AddTicks(1273), "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", null, null, "Any progress?" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 14, 8, 46, 26, 794, DateTimeKind.Utc).AddTicks(44), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, "This has been implemented" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 2, 1, new DateTime(2021, 11, 14, 8, 46, 26, 794, DateTimeKind.Utc).AddTicks(1271), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, "Nope" });
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
