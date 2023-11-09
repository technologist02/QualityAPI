using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class AmendPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "UsersInfo");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "UsersInfo",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "UsersInfo",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "UsersInfo",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
