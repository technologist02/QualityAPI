using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StandartQualityName_Name",
                table: "StandartQualityName");

            migrationBuilder.DropIndex(
                name: "IX_StandartQuality_FilmID_StandartQualityNameID",
                table: "StandartQuality");

            migrationBuilder.DropIndex(
                name: "IX_Film_Mark_Thickness_Color",
                table: "Film");

            migrationBuilder.DropIndex(
                name: "IX_Extruder_ExtruderName",
                table: "Extruder");

            migrationBuilder.CreateIndex(
                name: "IX_StandartQualityName_Name",
                table: "StandartQualityName",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StandartQuality_FilmID_StandartQualityNameID",
                table: "StandartQuality",
                columns: new[] { "FilmID", "StandartQualityNameID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Film_Mark_Thickness_Color",
                table: "Film",
                columns: new[] { "Mark", "Thickness", "Color" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Extruder_ExtruderName",
                table: "Extruder",
                column: "ExtruderName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StandartQualityName_Name",
                table: "StandartQualityName");

            migrationBuilder.DropIndex(
                name: "IX_StandartQuality_FilmID_StandartQualityNameID",
                table: "StandartQuality");

            migrationBuilder.DropIndex(
                name: "IX_Film_Mark_Thickness_Color",
                table: "Film");

            migrationBuilder.DropIndex(
                name: "IX_Extruder_ExtruderName",
                table: "Extruder");

            migrationBuilder.CreateIndex(
                name: "IX_StandartQualityName_Name",
                table: "StandartQualityName",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_StandartQuality_FilmID_StandartQualityNameID",
                table: "StandartQuality",
                columns: new[] { "FilmID", "StandartQualityNameID" });

            migrationBuilder.CreateIndex(
                name: "IX_Film_Mark_Thickness_Color",
                table: "Film",
                columns: new[] { "Mark", "Thickness", "Color" });

            migrationBuilder.CreateIndex(
                name: "IX_Extruder_ExtruderName",
                table: "Extruder",
                column: "ExtruderName");
        }
    }
}
