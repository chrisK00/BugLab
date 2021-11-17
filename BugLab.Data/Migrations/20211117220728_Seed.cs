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
                    { "757b2158-40c3-4917-9523-5861973a4d2e", 0, "87ae3ca7-0769-4369-a2fa-9757df337f9e", "chris@gmail.com", false, false, null, "CHRIS@GMAIL.COM", "CHRIS@GMAIL.COM", "AQAAAAEAACcQAAAAEK6FYJVTsn24rXmqs9/18zTYcMCU3JeOtvCL6jn8vcnszE9zb5Em8zY2mnB0jNzttQ==", null, false, "a31cea35-6c1a-4450-8ac1-8eb2de8a565a", false, "chris@gmail.com" },
                    { "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", 0, "8b4a38d6-27ca-4e4c-b4c1-89865ebfb8bd", "chrisk@gmail.com", false, false, null, "CHRISK@GMAIL.COM", "CHRISK@GMAIL.COM", "AQAAAAEAACcQAAAAEPmpdZmK1kk17IjlbIa2lzgULn/eQTEDoR0XbEyqR6CjdQtiielFuNxmXOK+voIezw==", null, false, "bde74562-2298-40d5-8a31-b8385a7d2b2d", false, "chrisk@gmail.com" }
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
                columns: new[] { "Id", "BugTypeId", "Created", "CreatedById", "Deleted", "DeletedById", "Description", "Modified", "ModifiedById", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, "Better domaine events pattern", null, null, "None", 1, "Open", "update project title" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "BugTypeId", "Created", "CreatedById", "Deleted", "DeletedById", "Description", "Modified", "ModifiedById", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", null, null, null, null, null, "None", 2, "Open", "How you doing?" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "BugTypeId", "Created", "CreatedById", "Deleted", "DeletedById", "Description", "Modified", "ModifiedById", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, null, null, null, "None", 1, "Open", "Implement project controllers" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Deleted", "DeletedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 3, 2, new DateTime(2021, 11, 17, 22, 7, 27, 455, DateTimeKind.Utc).AddTicks(537), "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", null, null, null, null, "Any progress?" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Deleted", "DeletedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 17, 22, 7, 27, 454, DateTimeKind.Utc).AddTicks(9965), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, null, null, "This has been implemented" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Deleted", "DeletedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 2, 1, new DateTime(2021, 11, 17, 22, 7, 27, 455, DateTimeKind.Utc).AddTicks(534), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, null, null, "Nope" });
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
