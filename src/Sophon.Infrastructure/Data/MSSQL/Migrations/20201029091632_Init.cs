using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sophon.Infrastructure.Data.MSSQL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asset_record",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_code = table.Column<string>(nullable: false),
                    type_name = table.Column<string>(nullable: false),
                    aggregate_amount = table.Column<decimal>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: false),
                    is_deleted = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset_record", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asset_type",
                columns: table => new
                {
                    code = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    method = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset_type", x => x.code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asset_type_name",
                table: "asset_type",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asset_record");

            migrationBuilder.DropTable(
                name: "asset_type");
        }
    }
}
