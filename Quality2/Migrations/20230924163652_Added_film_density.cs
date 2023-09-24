using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class Added_film_density : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StandartQualityName",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Density",
                table: "Film",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "StandartQualityName");

            migrationBuilder.DropColumn(
                name: "Density",
                table: "Film");
        }
    }
}
