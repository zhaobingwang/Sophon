using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sophon.App.Assistant.Infrastructure.Data.MSSQL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCode = table.Column<string>(maxLength: 64, nullable: false),
                    TypeName = table.Column<string>(maxLength: 64, nullable: false),
                    AggregateAmount = table.Column<decimal>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Method = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetType_Name",
                table: "AssetType",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetRecord");

            migrationBuilder.DropTable(
                name: "AssetType");
        }
    }
}
