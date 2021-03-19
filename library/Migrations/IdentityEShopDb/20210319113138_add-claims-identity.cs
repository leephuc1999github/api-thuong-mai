using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace library.Migrations.IdentityEShopDb
{
    public partial class addclaimsidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "AppUserClaims");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "AppRoleClaims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserClaims",
                table: "AppUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppRoleClaims",
                table: "AppRoleClaims",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f1ac2dcf-0f91-4a3d-9da5-ae2a34030b68");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "adae74b1-8280-425c-8771-10e5dc866a18", "AQAAAAEAACcQAAAAEOtfUZKD3jCXQq7Gu+IpYE2K0ZMTdJyRjPELcCstVLcDrHWGXzbVzeh/ad9eaB1nRQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserClaims",
                table: "AppUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppRoleClaims",
                table: "AppRoleClaims");

            migrationBuilder.RenameTable(
                name: "AppUserClaims",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "AppRoleClaims",
                newName: "RoleClaims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d037bce9-6847-44ae-9766-fa6ab5aa43c1");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1330c67e-7cdf-4eb2-aeed-5e4c3274d925", "AQAAAAEAACcQAAAAEIgNwMRXpH2mY6FRCJ8lqeFY5Z8gvdxBm3a68PDFmRTzCx4ySSCy96Ux1uK8A5iciQ==" });
        }
    }
}
