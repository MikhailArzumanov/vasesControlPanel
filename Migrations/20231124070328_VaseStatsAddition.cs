using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaseApi.Migrations
{
    /// <inheritdoc />
    public partial class VaseStatsAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FertilizedLevel",
                table: "Vases",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastFertilizing",
                table: "Vases",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "LightingLevel",
                table: "Vases",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FertilizedLevel",
                table: "Vases");

            migrationBuilder.DropColumn(
                name: "LastFertilizing",
                table: "Vases");

            migrationBuilder.DropColumn(
                name: "LightingLevel",
                table: "Vases");
        }
    }
}
