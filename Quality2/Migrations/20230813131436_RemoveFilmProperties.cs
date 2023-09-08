using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFilmProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderQuality_FilmProperties_FilmPropertyID",
                table: "OrderQuality");

            migrationBuilder.DropForeignKey(
                name: "FK_StandartQuality_FilmProperties_FilmPropertiesID",
                table: "StandartQuality");

            migrationBuilder.DropTable(
                name: "FilmProperties");

            migrationBuilder.DropIndex(
                name: "IX_StandartQuality_FilmID_StandartName",
                table: "StandartQuality");

            migrationBuilder.DropIndex(
                name: "IX_StandartQuality_FilmPropertiesID",
                table: "StandartQuality");

            migrationBuilder.DropIndex(
                name: "IX_OrderQuality_FilmPropertyID",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "StandartName",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "ExtruderName",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "FilmPropertyID",
                table: "OrderQuality");

            migrationBuilder.RenameColumn(
                name: "FilmPropertiesID",
                table: "StandartQuality",
                newName: "TensileStrengthTD");

            migrationBuilder.AddColumn<decimal>(
                name: "CoefficientOfFrictionD",
                table: "StandartQuality",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "CoefficientOfFrictionS",
                table: "StandartQuality",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CoronaTreatment",
                table: "StandartQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElongationAtBreakMD",
                table: "StandartQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElongationAtBreakTD",
                table: "StandartQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LightTransmission",
                table: "StandartQuality",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxThickness",
                table: "StandartQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinThickness",
                table: "StandartQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StandartQualityNameID",
                table: "StandartQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TensileStrengthMD",
                table: "StandartQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CoefficientOfFrictionD",
                table: "OrderQuality",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "CoefficientOfFrictionS",
                table: "OrderQuality",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CoronaTreatment",
                table: "OrderQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElongationAtBreakMD",
                table: "OrderQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElongationAtBreakTD",
                table: "OrderQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExtruderID",
                table: "OrderQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LightTransmission",
                table: "OrderQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxThickness",
                table: "OrderQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinThickness",
                table: "OrderQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StandartQualityNameID",
                table: "OrderQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TensileStrengthMD",
                table: "OrderQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TensileStrengthTD",
                table: "OrderQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StandartQualityName",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandartQualityName", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandartQuality_FilmID_StandartQualityNameID",
                table: "StandartQuality",
                columns: new[] { "FilmID", "StandartQualityNameID" });

            migrationBuilder.CreateIndex(
                name: "IX_StandartQualityName_Name",
                table: "StandartQualityName",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandartQualityName");

            migrationBuilder.DropIndex(
                name: "IX_StandartQuality_FilmID_StandartQualityNameID",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "CoefficientOfFrictionD",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "CoefficientOfFrictionS",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "CoronaTreatment",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "ElongationAtBreakMD",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "ElongationAtBreakTD",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "LightTransmission",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "MaxThickness",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "MinThickness",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "StandartQualityNameID",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "TensileStrengthMD",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "CoefficientOfFrictionD",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "CoefficientOfFrictionS",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "CoronaTreatment",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "ElongationAtBreakMD",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "ElongationAtBreakTD",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "ExtruderID",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "LightTransmission",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "MaxThickness",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "MinThickness",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "StandartQualityNameID",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "TensileStrengthMD",
                table: "OrderQuality");

            migrationBuilder.DropColumn(
                name: "TensileStrengthTD",
                table: "OrderQuality");

            migrationBuilder.RenameColumn(
                name: "TensileStrengthTD",
                table: "StandartQuality",
                newName: "FilmPropertiesID");

            migrationBuilder.AddColumn<string>(
                name: "StandartName",
                table: "StandartQuality",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtruderName",
                table: "OrderQuality",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FilmPropertyID",
                table: "OrderQuality",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilmProperties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CoefficientOfFrictionD = table.Column<decimal>(type: "numeric", nullable: false),
                    CoefficientOfFrictionS = table.Column<double>(type: "double precision", nullable: false),
                    CoronaTreatment = table.Column<int>(type: "integer", nullable: false),
                    ElongationAtBreakMD = table.Column<int>(type: "integer", nullable: false),
                    ElongationAtBreakTD = table.Column<int>(type: "integer", nullable: false),
                    LightTransmission = table.Column<int>(type: "integer", nullable: false),
                    MaxThickness = table.Column<int>(type: "integer", nullable: false),
                    MinThickness = table.Column<int>(type: "integer", nullable: false),
                    TensileStrengthMD = table.Column<int>(type: "integer", nullable: false),
                    TensileStrengthTD = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmProperties", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandartQuality_FilmID_StandartName",
                table: "StandartQuality",
                columns: new[] { "FilmID", "StandartName" });

            migrationBuilder.CreateIndex(
                name: "IX_StandartQuality_FilmPropertiesID",
                table: "StandartQuality",
                column: "FilmPropertiesID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderQuality_FilmPropertyID",
                table: "OrderQuality",
                column: "FilmPropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderQuality_FilmProperties_FilmPropertyID",
                table: "OrderQuality",
                column: "FilmPropertyID",
                principalTable: "FilmProperties",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StandartQuality_FilmProperties_FilmPropertiesID",
                table: "StandartQuality",
                column: "FilmPropertiesID",
                principalTable: "FilmProperties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
