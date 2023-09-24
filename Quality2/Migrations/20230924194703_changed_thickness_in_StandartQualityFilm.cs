using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class changed_thickness_in_StandartQualityFilm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxThickness",
                table: "StandartQuality");

            migrationBuilder.RenameColumn(
                name: "MinThickness",
                table: "StandartQuality",
                newName: "ThicknessVariation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThicknessVariation",
                table: "StandartQuality",
                newName: "MinThickness");

            migrationBuilder.AddColumn<int>(
                name: "MaxThickness",
                table: "StandartQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
