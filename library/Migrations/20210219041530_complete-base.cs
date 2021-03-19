using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace library.Migrations
{
    public partial class completebase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kys");

            migrationBuilder.AddColumn<int>(
                name: "GiamDocId",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhuVucQuanLy",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NhanVienDaiDien_ChucVu",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NhanVienQuanLy_ChucVu",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NhanVienQuanLy_KhuVucQuanLy",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoiTacId",
                table: "HopDongs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhanVienDaiDienId",
                table: "HopDongs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CuaHangs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    DienTich = table.Column<float>(nullable: true),
                    ViTri = table.Column<string>(nullable: true),
                    NhanVienQuanLyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHangs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CuaHangs_NhanViens_NhanVienQuanLyId",
                        column: x => x.NhanVienQuanLyId,
                        principalTable: "NhanViens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiamDocs",
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
                    NamKinhNghiem = table.Column<int>(nullable: false),
                    SDT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamDocs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MatHangs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    Loai = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatHangs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChiNhanhs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    GioHoatDong = table.Column<string>(nullable: true),
                    TenChiNhanh = table.Column<string>(nullable: true),
                    GiamDocId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiNhanhs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiNhanhs_GiamDocs_GiamDocId",
                        column: x => x.GiamDocId,
                        principalTable: "GiamDocs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KinhDoanhs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CuaHangId = table.Column<int>(nullable: true),
                    MatHangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KinhDoanhs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KinhDoanhs_CuaHangs_CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHangs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KinhDoanhs_MatHangs_MatHangId",
                        column: x => x.MatHangId,
                        principalTable: "MatHangs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TinhThanhs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    MaTinhThanh = table.Column<int>(nullable: false),
                    TenTinhThanh = table.Column<string>(nullable: true),
                    ThanhPho = table.Column<string>(nullable: true),
                    ChiNhanhId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhThanhs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TinhThanhs_ChiNhanhs_ChiNhanhId",
                        column: x => x.ChiNhanhId,
                        principalTable: "ChiNhanhs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
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
                    NamSinh = table.Column<int>(nullable: false),
                    SDT = table.Column<string>(nullable: true),
                    TinhThanhId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KhachHangs_TinhThanhs_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "TinhThanhs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiamSats",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    KhachHangId = table.Column<int>(nullable: true),
                    NhanVienBaoVeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamSats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GiamSats_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiamSats_NhanViens_NhanVienBaoVeId",
                        column: x => x.NhanVienBaoVeId,
                        principalTable: "NhanViens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Muas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    KhachHangId = table.Column<int>(nullable: true),
                    MatHangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Muas_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Muas_MatHangs_MatHangId",
                        column: x => x.MatHangId,
                        principalTable: "MatHangs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_GiamDocId",
                table: "NhanViens",
                column: "GiamDocId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_DoiTacId",
                table: "HopDongs",
                column: "DoiTacId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_NhanVienDaiDienId",
                table: "HopDongs",
                column: "NhanVienDaiDienId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiNhanhs_GiamDocId",
                table: "ChiNhanhs",
                column: "GiamDocId");

            migrationBuilder.CreateIndex(
                name: "IX_CuaHangs_NhanVienQuanLyId",
                table: "CuaHangs",
                column: "NhanVienQuanLyId");

            migrationBuilder.CreateIndex(
                name: "IX_GiamSats_KhachHangId",
                table: "GiamSats",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_GiamSats_NhanVienBaoVeId",
                table: "GiamSats",
                column: "NhanVienBaoVeId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_TinhThanhId",
                table: "KhachHangs",
                column: "TinhThanhId");

            migrationBuilder.CreateIndex(
                name: "IX_KinhDoanhs_CuaHangId",
                table: "KinhDoanhs",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_KinhDoanhs_MatHangId",
                table: "KinhDoanhs",
                column: "MatHangId");

            migrationBuilder.CreateIndex(
                name: "IX_Muas_KhachHangId",
                table: "Muas",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_Muas_MatHangId",
                table: "Muas",
                column: "MatHangId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanhs_ChiNhanhId",
                table: "TinhThanhs",
                column: "ChiNhanhId");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongs_DoiTacs_DoiTacId",
                table: "HopDongs",
                column: "DoiTacId",
                principalTable: "DoiTacs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongs_NhanViens_NhanVienDaiDienId",
                table: "HopDongs",
                column: "NhanVienDaiDienId",
                principalTable: "NhanViens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_GiamDocs_GiamDocId",
                table: "NhanViens",
                column: "GiamDocId",
                principalTable: "GiamDocs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDongs_DoiTacs_DoiTacId",
                table: "HopDongs");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDongs_NhanViens_NhanVienDaiDienId",
                table: "HopDongs");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanViens_GiamDocs_GiamDocId",
                table: "NhanViens");

            migrationBuilder.DropTable(
                name: "GiamSats");

            migrationBuilder.DropTable(
                name: "KinhDoanhs");

            migrationBuilder.DropTable(
                name: "Muas");

            migrationBuilder.DropTable(
                name: "CuaHangs");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "MatHangs");

            migrationBuilder.DropTable(
                name: "TinhThanhs");

            migrationBuilder.DropTable(
                name: "ChiNhanhs");

            migrationBuilder.DropTable(
                name: "GiamDocs");

            migrationBuilder.DropIndex(
                name: "IX_NhanViens_GiamDocId",
                table: "NhanViens");

            migrationBuilder.DropIndex(
                name: "IX_HopDongs_DoiTacId",
                table: "HopDongs");

            migrationBuilder.DropIndex(
                name: "IX_HopDongs_NhanVienDaiDienId",
                table: "HopDongs");

            migrationBuilder.DropColumn(
                name: "GiamDocId",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "KhuVucQuanLy",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "NhanVienDaiDien_ChucVu",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "NhanVienQuanLy_ChucVu",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "NhanVienQuanLy_KhuVucQuanLy",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "DoiTacId",
                table: "HopDongs");

            migrationBuilder.DropColumn(
                name: "NhanVienDaiDienId",
                table: "HopDongs");

            migrationBuilder.CreateTable(
                name: "Kys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoiTacId = table.Column<int>(type: "int", nullable: true),
                    HopDongId = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienDaiDienId = table.Column<int>(type: "int", nullable: true)
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
    }
}
