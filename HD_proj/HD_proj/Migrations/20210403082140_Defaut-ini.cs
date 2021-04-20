using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HD_proj.Migrations
{
    public partial class Defautini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastOnline",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "Phongban",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Chitietduan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Chitiet = table.Column<string>(nullable: true),
                    Tinhtrang = table.Column<int>(nullable: false),
                    Duan = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietduan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhmucFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    TenLoai = table.Column<string>(nullable: true),
                    DuongDan = table.Column<string>(nullable: true),
                    PhanMoRong = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    LoaiDulieu = table.Column<string>(nullable: true),
                    FatherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    Mota = table.Column<string>(nullable: true),
                    Thoihan = table.Column<DateTime>(nullable: false),
                    Hoanthanh = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phancong",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    ChitietDuan = table.Column<Guid>(nullable: false),
                    Nguoilam = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phancong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phongbans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    Cap = table.Column<int>(nullable: false),
                    Ma = table.Column<string>(nullable: true),
                    MaPhongbanCha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phongbans", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitietduan");

            migrationBuilder.DropTable(
                name: "DanhmucFiles");

            migrationBuilder.DropTable(
                name: "Duan");

            migrationBuilder.DropTable(
                name: "Phancong");

            migrationBuilder.DropTable(
                name: "Phongbans");

            migrationBuilder.DropColumn(
                name: "Phongban",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastOnline",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }
    }
}
