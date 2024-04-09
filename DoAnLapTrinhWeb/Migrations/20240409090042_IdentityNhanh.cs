using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLapTrinhWeb.Migrations
{
    /// <inheritdoc />
    public partial class IdentityNhanh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbChiTietTheLoai_tbTheLoai_tbTheLoaimaTheLoai",
                table: "tbChiTietTheLoai");

            migrationBuilder.RenameColumn(
                name: "maTheLoai",
                table: "tbTheLoai",
                newName: "TheLoaiId");

            migrationBuilder.RenameColumn(
                name: "tbTheLoaimaTheLoai",
                table: "tbChiTietTheLoai",
                newName: "tbTheLoaiTheLoaiId");

            migrationBuilder.RenameIndex(
                name: "IX_tbChiTietTheLoai_tbTheLoaimaTheLoai",
                table: "tbChiTietTheLoai",
                newName: "IX_tbChiTietTheLoai_tbTheLoaiTheLoaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbChiTietTheLoai_tbTheLoai_tbTheLoaiTheLoaiId",
                table: "tbChiTietTheLoai",
                column: "tbTheLoaiTheLoaiId",
                principalTable: "tbTheLoai",
                principalColumn: "TheLoaiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbChiTietTheLoai_tbTheLoai_tbTheLoaiTheLoaiId",
                table: "tbChiTietTheLoai");

            migrationBuilder.RenameColumn(
                name: "TheLoaiId",
                table: "tbTheLoai",
                newName: "maTheLoai");

            migrationBuilder.RenameColumn(
                name: "tbTheLoaiTheLoaiId",
                table: "tbChiTietTheLoai",
                newName: "tbTheLoaimaTheLoai");

            migrationBuilder.RenameIndex(
                name: "IX_tbChiTietTheLoai_tbTheLoaiTheLoaiId",
                table: "tbChiTietTheLoai",
                newName: "IX_tbChiTietTheLoai_tbTheLoaimaTheLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_tbChiTietTheLoai_tbTheLoai_tbTheLoaimaTheLoai",
                table: "tbChiTietTheLoai",
                column: "tbTheLoaimaTheLoai",
                principalTable: "tbTheLoai",
                principalColumn: "maTheLoai");
        }
    }
}
