using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStandartQuality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandartQuality_FilmProperties_FilmPropertyID",
                table: "StandartQuality");

            migrationBuilder.RenameColumn(
                name: "FilmPropertyID",
                table: "StandartQuality",
                newName: "FilmPropertiesID");

            migrationBuilder.RenameIndex(
                name: "IX_StandartQuality_FilmPropertyID",
                table: "StandartQuality",
                newName: "IX_StandartQuality_FilmPropertiesID");

            migrationBuilder.CreateTable(
                name: "Extruder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExtruderName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extruder", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extruder_ExtruderName",
                table: "Extruder",
                column: "ExtruderName");

            migrationBuilder.AddForeignKey(
                name: "FK_StandartQuality_FilmProperties_FilmPropertiesID",
                table: "StandartQuality",
                column: "FilmPropertiesID",
                principalTable: "FilmProperties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandartQuality_FilmProperties_FilmPropertiesID",
                table: "StandartQuality");

            migrationBuilder.DropTable(
                name: "Extruder");

            migrationBuilder.RenameColumn(
                name: "FilmPropertiesID",
                table: "StandartQuality",
                newName: "FilmPropertyID");

            migrationBuilder.RenameIndex(
                name: "IX_StandartQuality_FilmPropertiesID",
                table: "StandartQuality",
                newName: "IX_StandartQuality_FilmPropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_StandartQuality_FilmProperties_FilmPropertyID",
                table: "StandartQuality",
                column: "FilmPropertyID",
                principalTable: "FilmProperties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
