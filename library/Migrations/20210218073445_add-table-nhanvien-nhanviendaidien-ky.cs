using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace library.Migrations
{
    public partial class addtablenhanviennhanviendaidienky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CMT = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: true),
                    SDT = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ChucVu = table.Column<string>(nullable: true),
                    LinhVuc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kys",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DoiTacId = table.Column<int>(nullable: true),
                    HopDongId = table.Column<int>(nullable: true),
                    NhanVienDaiDienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kys_DoiTacs_DoiTacId",
                        column: x => x.DoiTacId,
                        principalTable: "DoiTacs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kys_HopDongs_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDongs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kys_NhanViens_NhanVienDaiDienId",
                        column: x => x.NhanVienDaiDienId,
                        principalTable: "NhanViens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kys_DoiTacId",
                table: "Kys",
                column: "DoiTacId");

            migrationBuilder.CreateIndex(
                name: "IX_Kys_HopDongId",
                table: "Kys",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_Kys_NhanVienDaiDienId",
                table: "Kys",
                column: "NhanVienDaiDienId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kys");

            migrationBuilder.DropTable(
                name: "NhanViens");
        }
    }
}
