using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class RefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "530223b3-ed1a-4b17-b834-3b3ee167f26d", "AQAAAAEAACcQAAAAEAnsXsh+Cs/vtb5i36/kY2WBvDus5YdueNm7zpi+nAaeb79rl/KCx5zpzl+2A+E3EQ==", "0294c916-29e1-4c13-ae23-b6ab6fc6d11e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d507f49-52bb-400c-86dc-2dcbc9b4105f", "AQAAAAEAACcQAAAAEL57E0d3Y34SaL2s/ZYMGDXmVHJASdS3EiCJWNY0SH1ktLuYm2J83gguSxSz4I4lwA==", "50ab8697-9bd8-43e6-8d47-0aaf0775fdff" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 3, 31, 17, 26, 56, 343, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 3, 31, 17, 26, 56, 343, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 3, 31, 17, 26, 56, 343, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3829ec37-3b44-49a0-9dd3-186638bd48c7", "AQAAAAEAACcQAAAAEKF92QNc18qicu8l/pTja/J1ztX2aBdZcXZTFpin4c86WnRoRZgfEGyzVInmJfKiUg==", "1e4468c4-fdf0-4f90-9643-8ed4e9a31cd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9f4c02b-c257-4277-ab42-25e3142336e3", "AQAAAAEAACcQAAAAEGLXRN1EB4OhgrScaj4pOaVdBwMUxCK/KuiD1bLZrf0Heah4Cu+GCPBUIBl/Vpufjg==", "ac6a4862-4dff-4519-85c3-05e2ebc2335c" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 3, 24, 7, 49, 32, 75, DateTimeKind.Utc).AddTicks(1694));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 3, 24, 7, 49, 32, 75, DateTimeKind.Utc).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 3, 24, 7, 49, 32, 75, DateTimeKind.Utc).AddTicks(2291));
        }
    }
}
