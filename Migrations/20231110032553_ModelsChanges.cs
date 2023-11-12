using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaseApi.Migrations {
    /// <inheritdoc />
    public partial class ModelsChanges : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<bool>(
                name: "Autofertilizeing",
                table: "Vases",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Autowatering",
                table: "Vases",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "FertilizingIntensity",
                table: "Vases",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GlassOpacity",
                table: "Vases",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLightingToggled",
                table: "Vases",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "LightingIntensity",
                table: "Vases",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WateringIntensity",
                table: "Vases",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "Autofertilizeing",
                table: "Vases");

            migrationBuilder.DropColumn(
                name: "Autowatering",
                table: "Vases");

            migrationBuilder.DropColumn(
                name: "FertilizingIntensity",
                table: "Vases");

            migrationBuilder.DropColumn(
                name: "GlassOpacity",
                table: "Vases");

            migrationBuilder.DropColumn(
                name: "IsLightingToggled",
                table: "Vases");

            migrationBuilder.DropColumn(
                name: "LightingIntensity",
                table: "Vases");

            migrationBuilder.DropColumn(
                name: "WateringIntensity",
                table: "Vases");
        }
    }
}
