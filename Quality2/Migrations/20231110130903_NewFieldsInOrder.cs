using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InspectionDate",
                table: "OrdersQuality",
                newName: "CreationDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsInspected",
                table: "OrdersQuality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsQualityMatches",
                table: "OrdersQuality",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInspected",
                table: "OrdersQuality");

            migrationBuilder.DropColumn(
                name: "IsQualityMatches",
                table: "OrdersQuality");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "OrdersQuality",
                newName: "InspectionDate");
        }
    }
}
