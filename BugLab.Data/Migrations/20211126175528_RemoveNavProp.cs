using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class RemoveNavProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserProject");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityUserProject",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserProject", x => new { x.ProjectsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_IdentityUserProject_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "757b2158-40c3-4917-9523-5861973a4d2e", 0, "ca10ad6a-7b2d-4257-aba8-9c053b11f3dc", "chris@gmail.com", false, false, null, "CHRIS@GMAIL.COM", "CHRIS@GMAIL.COM", "AQAAAAEAACcQAAAAEMU5WL5+FMiBB/C2mqP9r+4xxF//5pCOjSXs01YRRnH76DuMCesd+gIrp2BEes7/Pg==", null, false, "e04c9725-1613-4d09-b521-b68d56eaf678", false, "chris@gmail.com" },
                    { "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", 0, "cbb2c297-6f8d-42a4-9654-5f8e535a25c1", "chrisk@gmail.com", false, false, null, "CHRISK@GMAIL.COM", "CHRISK@GMAIL.COM", "AQAAAAEAACcQAAAAECJF6h3jAGoeU6DA4OXrvvxanPjzrFcl71Yt05+5ug++6YGz9LgxLLyX+wTm/zLoDA==", null, false, "f2b0c232-3a99-45b7-8cb7-518d92936e82", false, "chrisk@gmail.com" }
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
                values: new object[] { 3, 2, new DateTime(2021, 11, 26, 17, 24, 37, 866, DateTimeKind.Utc).AddTicks(7918), "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62", null, null, null, null, "Any progress?" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Deleted", "DeletedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 26, 17, 24, 37, 866, DateTimeKind.Utc).AddTicks(7304), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, null, null, "This has been implemented" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "CreatedById", "Deleted", "DeletedById", "Modified", "ModifiedById", "Text" },
                values: new object[] { 2, 1, new DateTime(2021, 11, 26, 17, 24, 37, 866, DateTimeKind.Utc).AddTicks(7915), "757b2158-40c3-4917-9523-5861973a4d2e", null, null, null, null, "Nope" });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserProject_UsersId",
                table: "IdentityUserProject",
                column: "UsersId");
        }
    }
}
