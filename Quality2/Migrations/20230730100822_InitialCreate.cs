using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mark = table.Column<string>(type: "text", nullable: false),
                    Thickness = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FilmProperties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MinThickness = table.Column<int>(type: "integer", nullable: false),
                    MaxThickness = table.Column<int>(type: "integer", nullable: false),
                    TensileStrengthMD = table.Column<int>(type: "integer", nullable: false),
                    TensileStrengthTD = table.Column<int>(type: "integer", nullable: false),
                    ElongationAtBreakMD = table.Column<int>(type: "integer", nullable: false),
                    ElongationAtBreakTD = table.Column<int>(type: "integer", nullable: false),
                    CoefficientOfFrictionS = table.Column<double>(type: "double precision", nullable: false),
                    CoefficientOfFrictionD = table.Column<double>(type: "double precision", nullable: false),
                    LightTransmission = table.Column<int>(type: "integer", nullable: false),
                    CoronaTreatment = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmProperties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderQuality",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderNumber = table.Column<int>(type: "integer", nullable: false),
                    Customer = table.Column<string>(type: "text", nullable: true),
                    ProductionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BrigadeNumber = table.Column<int>(type: "integer", nullable: false),
                    RollNumber = table.Column<int>(type: "integer", nullable: false),
                    ExtruderName = table.Column<string>(type: "text", nullable: false),
                    FilmID = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    FilmPropertyID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderQuality", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderQuality_FilmProperties_FilmPropertyID",
                        column: x => x.FilmPropertyID,
                        principalTable: "FilmProperties",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "QualityStandarts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmID = table.Column<int>(type: "integer", nullable: false),
                    FilmPropertyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityStandarts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QualityStandarts_FilmProperties_FilmPropertyID",
                        column: x => x.FilmPropertyID,
                        principalTable: "FilmProperties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderQuality_FilmPropertyID",
                table: "OrderQuality",
                column: "FilmPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandarts_FilmPropertyID",
                table: "QualityStandarts",
                column: "FilmPropertyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "OrderQuality");

            migrationBuilder.DropTable(
                name: "QualityStandarts");

            migrationBuilder.DropTable(
                name: "FilmProperties");
        }
    }
}
