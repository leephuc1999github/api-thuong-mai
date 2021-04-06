using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace library.Migrations.EShopDb
{
    public partial class addfieldIconforlanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 17, 30, 20, 434, DateTimeKind.Local).AddTicks(6246),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 24, 14, 41, 18, 840, DateTimeKind.Local).AddTicks(7319));

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Languages",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 4, 17, 30, 20, 451, DateTimeKind.Local).AddTicks(2803));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Languages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 24, 14, 41, 18, 840, DateTimeKind.Local).AddTicks(7319),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 4, 17, 30, 20, 434, DateTimeKind.Local).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 14, 41, 18, 857, DateTimeKind.Local).AddTicks(1951));
        }
    }
}
