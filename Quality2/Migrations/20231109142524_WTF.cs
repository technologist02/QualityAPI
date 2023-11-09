using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class WTF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_UsersInfo_UserDtoID",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "UserDtoID",
                table: "Roles",
                newName: "UserDtoId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_UserDtoID",
                table: "Roles",
                newName: "IX_Roles_UserDtoId");

            migrationBuilder.AlterColumn<int>(
                name: "UserDtoId",
                table: "Roles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_UsersInfo_UserDtoId",
                table: "Roles",
                column: "UserDtoId",
                principalTable: "UsersInfo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_UsersInfo_UserDtoId",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "UserDtoId",
                table: "Roles",
                newName: "UserDtoID");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_UserDtoId",
                table: "Roles",
                newName: "IX_Roles_UserDtoID");

            migrationBuilder.AlterColumn<int>(
                name: "UserDtoID",
                table: "Roles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_UsersInfo_UserDtoID",
                table: "Roles",
                column: "UserDtoID",
                principalTable: "UsersInfo",
                principalColumn: "ID");
        }
    }
}
