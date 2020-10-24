using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sophon.Infrastructure.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asset_records",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeCode = table.Column<string>(nullable: false),
                    TypeName = table.Column<string>(nullable: true),
                    AggregateAmount = table.Column<decimal>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset_records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "asset_type",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Method = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset_type", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asset_type_Name",
                table: "asset_type",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asset_records");

            migrationBuilder.DropTable(
                name: "asset_type");
        }
    }
}
