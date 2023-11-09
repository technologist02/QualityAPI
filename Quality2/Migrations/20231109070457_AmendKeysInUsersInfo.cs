using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class AmendKeysInUsersInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_Name",
                table: "UsersInfo");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_Login",
                table: "UsersInfo",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_Login",
                table: "UsersInfo");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_Name",
                table: "UsersInfo",
                column: "Name",
                unique: true);
        }
    }
}
