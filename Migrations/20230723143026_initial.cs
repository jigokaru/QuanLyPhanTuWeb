using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyPhanTuWeb.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chuas",
                columns: table => new
                {
                    chuaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    diaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngayThanhLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tenChua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    truTri = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chuas", x => x.chuaId);
                });

            migrationBuilder.CreateTable(
                name: "KieuThanhViens",
                columns: table => new
                {
                    kieuThanhVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenKieu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KieuThanhViens", x => x.kieuThanhVienId);
                });

            migrationBuilder.CreateTable(
                name: "PhanTu",
                columns: table => new
                {
                    phatTuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anhChup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    daHoanTuc = table.Column<bool>(type: "bit", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tenDem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngayCapNhap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ngayHoanTuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ngayXuatGia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    phapDanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    soDienThoai = table.Column<int>(type: "int", nullable: true),
                    chuaId = table.Column<int>(type: "int", nullable: true),
                    kieuThanhVienId = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanTu", x => x.phatTuId);
                    table.ForeignKey(
                        name: "FK_PhanTu_Chuas_chuaId",
                        column: x => x.chuaId,
                        principalTable: "Chuas",
                        principalColumn: "chuaId");
                    table.ForeignKey(
                        name: "FK_PhanTu_KieuThanhViens_kieuThanhVienId",
                        column: x => x.kieuThanhVienId,
                        principalTable: "KieuThanhViens",
                        principalColumn: "kieuThanhVienId");
                });

            migrationBuilder.CreateTable(
                name: "DaoTrangs",
                columns: table => new
                {
                    daoTrangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    daKetThuc = table.Column<bool>(type: "bit", nullable: false),
                    noiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noiToChuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    soThanhVienThamGia = table.Column<int>(type: "int", nullable: true),
                    thoiGianToChuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    phatTuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaoTrangs", x => x.daoTrangId);
                    table.ForeignKey(
                        name: "FK_DaoTrangs_PhanTu_phatTuId",
                        column: x => x.phatTuId,
                        principalTable: "PhanTu",
                        principalColumn: "phatTuId");
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stoken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    expired = table.Column<bool>(type: "bit", nullable: true),
                    revoked = table.Column<bool>(type: "bit", nullable: true),
                    token_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phatTuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_PhanTu_phatTuId",
                        column: x => x.phatTuId,
                        principalTable: "PhanTu",
                        principalColumn: "phatTuId");
                });

            migrationBuilder.CreateTable(
                name: "TokenResetPassword",
                columns: table => new
                {
                    PasswordResetTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emailToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    phatTuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenResetPassword", x => x.PasswordResetTokenId);
                    table.ForeignKey(
                        name: "FK_TokenResetPassword_PhanTu_phatTuId",
                        column: x => x.phatTuId,
                        principalTable: "PhanTu",
                        principalColumn: "phatTuId");
                });

            migrationBuilder.CreateTable(
                name: "DonDangKys",
                columns: table => new
                {
                    donDangkyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ngayGuiDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayXuLy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nguoiXuLy = table.Column<int>(type: "int", nullable: false),
                    trangThaiDon = table.Column<bool>(type: "bit", nullable: false),
                    phatTuId = table.Column<int>(type: "int", nullable: true),
                    daoTrangId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDangKys", x => x.donDangkyId);
                    table.ForeignKey(
                        name: "FK_DonDangKys_DaoTrangs_daoTrangId",
                        column: x => x.daoTrangId,
                        principalTable: "DaoTrangs",
                        principalColumn: "daoTrangId");
                    table.ForeignKey(
                        name: "FK_DonDangKys_PhanTu_phatTuId",
                        column: x => x.phatTuId,
                        principalTable: "PhanTu",
                        principalColumn: "phatTuId");
                });

            migrationBuilder.CreateTable(
                name: "PhatTuDaoTrangs",
                columns: table => new
                {
                    phatTuDaoTrangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    daThamGia = table.Column<bool>(type: "bit", nullable: false),
                    lyDoKhongThamGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    daoTrangId = table.Column<int>(type: "int", nullable: true),
                    phatTuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhatTuDaoTrangs", x => x.phatTuDaoTrangId);
                    table.ForeignKey(
                        name: "FK_PhatTuDaoTrangs_DaoTrangs_daoTrangId",
                        column: x => x.daoTrangId,
                        principalTable: "DaoTrangs",
                        principalColumn: "daoTrangId");
                    table.ForeignKey(
                        name: "FK_PhatTuDaoTrangs_PhanTu_phatTuId",
                        column: x => x.phatTuId,
                        principalTable: "PhanTu",
                        principalColumn: "phatTuId");
                });

            migrationBuilder.InsertData(
                table: "PhanTu",
                columns: new[] { "phatTuId", "Role", "anhChup", "chuaId", "daHoanTuc", "email", "gioiTinh", "ho", "isActive", "kieuThanhVienId", "ngayCapNhap", "ngayHoanTuc", "ngaySinh", "ngayXuatGia", "password", "phapDanh", "soDienThoai", "ten", "tenDem" },
                values: new object[,]
                {
                    { 2, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 3, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 4, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 5, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 6, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 7, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 8, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 9, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 10, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 11, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 12, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 13, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 14, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 15, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 16, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 17, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 18, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 19, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaoTrangs_phatTuId",
                table: "DaoTrangs",
                column: "phatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKys_daoTrangId",
                table: "DonDangKys",
                column: "daoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKys_phatTuId",
                table: "DonDangKys",
                column: "phatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanTu_chuaId",
                table: "PhanTu",
                column: "chuaId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanTu_kieuThanhVienId",
                table: "PhanTu",
                column: "kieuThanhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTuDaoTrangs_daoTrangId",
                table: "PhatTuDaoTrangs",
                column: "daoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTuDaoTrangs_phatTuId",
                table: "PhatTuDaoTrangs",
                column: "phatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_phatTuId",
                table: "Token",
                column: "phatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenResetPassword_phatTuId",
                table: "TokenResetPassword",
                column: "phatTuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonDangKys");

            migrationBuilder.DropTable(
                name: "PhatTuDaoTrangs");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "TokenResetPassword");

            migrationBuilder.DropTable(
                name: "DaoTrangs");

            migrationBuilder.DropTable(
                name: "PhanTu");

            migrationBuilder.DropTable(
                name: "Chuas");

            migrationBuilder.DropTable(
                name: "KieuThanhViens");
        }
    }
}
