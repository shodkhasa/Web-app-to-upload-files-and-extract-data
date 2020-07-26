using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Homework3.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityDailyCaseDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Death = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Cases = table.Column<int>(nullable: false),
                    Test = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityDailyCaseDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Pop = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityDailyCaseDatas");

            migrationBuilder.DropTable(
                name: "CityDatas");
        }
    }
}
