using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace vaseApi.Migrations {
    /// <inheritdoc />
    public partial class FirstSetOfModels : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Commentary = table.Column<string>(type: "text", nullable: false),
                    HexRepresentation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genuses",
                columns: table => new {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HtmlMarkup = table.Column<string>(type: "text", nullable: false),
                    MarkdownText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Genuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vases",
                columns: table => new {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Commentary = table.Column<string>(type: "text", nullable: true),
                    LastWatering = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WateredLevel = table.Column<double>(type: "double precision", nullable: false),
                    MainColorId = table.Column<int>(type: "integer", nullable: false),
                    SideColorId = table.Column<int>(type: "integer", nullable: false),
                    FlowerGenusId = table.Column<int>(type: "integer", nullable: false),
                    VaseCondition = table.Column<int>(type: "integer", nullable: false),
                    VaseWeight = table.Column<double>(type: "double precision", nullable: false),
                    LastRepairDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MountingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Vases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vases_Colors_MainColorId",
                        column: x => x.MainColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vases_Colors_SideColorId",
                        column: x => x.SideColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vases_Genuses_FlowerGenusId",
                        column: x => x.FlowerGenusId,
                        principalTable: "Genuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vases_FlowerGenusId",
                table: "Vases",
                column: "FlowerGenusId");

            migrationBuilder.CreateIndex(
                name: "IX_Vases_MainColorId",
                table: "Vases",
                column: "MainColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vases_SideColorId",
                table: "Vases",
                column: "SideColorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Vases");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Genuses");
        }
    }
}
