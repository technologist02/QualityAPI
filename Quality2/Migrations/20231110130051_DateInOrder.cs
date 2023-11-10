using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class DateInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InspectionDate",
                table: "OrdersQuality",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InspectorId",
                table: "OrdersQuality",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersQuality_InspectorId",
                table: "OrdersQuality",
                column: "InspectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersQuality_Users_InspectorId",
                table: "OrdersQuality",
                column: "InspectorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersQuality_Users_InspectorId",
                table: "OrdersQuality");

            migrationBuilder.DropIndex(
                name: "IX_OrdersQuality_InspectorId",
                table: "OrdersQuality");

            migrationBuilder.DropColumn(
                name: "InspectionDate",
                table: "OrdersQuality");

            migrationBuilder.DropColumn(
                name: "InspectorId",
                table: "OrdersQuality");
        }
    }
}
