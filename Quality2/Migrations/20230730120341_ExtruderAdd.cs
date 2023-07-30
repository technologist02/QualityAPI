using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class ExtruderAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityStandarts_FilmProperties_FilmPropertyID",
                table: "QualityStandarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualityStandarts",
                table: "QualityStandarts");

            migrationBuilder.RenameTable(
                name: "QualityStandarts",
                newName: "StandartQuality");

            migrationBuilder.RenameIndex(
                name: "IX_QualityStandarts_FilmPropertyID",
                table: "StandartQuality",
                newName: "IX_StandartQuality_FilmPropertyID");

            migrationBuilder.AlterColumn<decimal>(
                name: "CoefficientOfFrictionD",
                table: "FilmProperties",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<string>(
                name: "StandartName",
                table: "StandartQuality",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StandartQuality",
                table: "StandartQuality",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_Mark_Thickness_Color",
                table: "Film",
                columns: new[] { "Mark", "Thickness", "Color" });

            migrationBuilder.CreateIndex(
                name: "IX_StandartQuality_FilmID_StandartName",
                table: "StandartQuality",
                columns: new[] { "FilmID", "StandartName" });

            migrationBuilder.AddForeignKey(
                name: "FK_StandartQuality_FilmProperties_FilmPropertyID",
                table: "StandartQuality",
                column: "FilmPropertyID",
                principalTable: "FilmProperties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandartQuality_FilmProperties_FilmPropertyID",
                table: "StandartQuality");

            migrationBuilder.DropIndex(
                name: "IX_Film_Mark_Thickness_Color",
                table: "Film");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StandartQuality",
                table: "StandartQuality");

            migrationBuilder.DropIndex(
                name: "IX_StandartQuality_FilmID_StandartName",
                table: "StandartQuality");

            migrationBuilder.DropColumn(
                name: "StandartName",
                table: "StandartQuality");

            migrationBuilder.RenameTable(
                name: "StandartQuality",
                newName: "QualityStandarts");

            migrationBuilder.RenameIndex(
                name: "IX_StandartQuality_FilmPropertyID",
                table: "QualityStandarts",
                newName: "IX_QualityStandarts_FilmPropertyID");

            migrationBuilder.AlterColumn<double>(
                name: "CoefficientOfFrictionD",
                table: "FilmProperties",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualityStandarts",
                table: "QualityStandarts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityStandarts_FilmProperties_FilmPropertyID",
                table: "QualityStandarts",
                column: "FilmPropertyID",
                principalTable: "FilmProperties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
