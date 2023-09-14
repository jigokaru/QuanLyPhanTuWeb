using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyPhanTuWeb.Migrations
{
    /// <inheritdoc />
    public partial class update_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 19);

            migrationBuilder.InsertData(
                table: "PhanTu",
                columns: new[] { "phatTuId", "Role", "anhChup", "chuaId", "daHoanTuc", "email", "gioiTinh", "ho", "isActive", "kieuThanhVienId", "ngayCapNhap", "ngayHoanTuc", "ngaySinh", "ngayXuatGia", "password", "phapDanh", "soDienThoai", "ten", "tenDem" },
                values: new object[,]
                {
                    { 21, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 22, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 23, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 24, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 25, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 26, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 27, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 28, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 29, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 30, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 31, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 32, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 33, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 34, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 35, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 36, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 37, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 38, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null },
                    { 39, "", null, null, null, "", null, null, true, null, null, null, null, null, "", null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "PhanTu",
                keyColumn: "phatTuId",
                keyValue: 39);

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
        }
    }
}
