using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Quality2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Extruders",
                columns: table => new
                {
                    ExtruderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extruders", x => x.ExtruderId);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mark = table.Column<string>(type: "text", nullable: false),
                    Thickness = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Density = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmId);
                });

            migrationBuilder.CreateTable(
                name: "StandartQualityTitles",
                columns: table => new
                {
                    StandartQualityTitleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandartQualityTitles", x => x.StandartQualityTitleId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Function = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "OrdersQuality",
                columns: table => new
                {
                    OrderQualityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderNumber = table.Column<int>(type: "integer", nullable: false),
                    Customer = table.Column<string>(type: "text", nullable: true),
                    ProductionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BrigadeNumber = table.Column<int>(type: "integer", nullable: false),
                    RollNumber = table.Column<int>(type: "integer", nullable: false),
                    ExtruderId = table.Column<int>(type: "integer", nullable: false),
                    FilmId = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    MinThickness = table.Column<int>(type: "integer", nullable: false),
                    MaxThickness = table.Column<int>(type: "integer", nullable: false),
                    TensileStrengthMD = table.Column<double>(type: "double precision", nullable: false),
                    TensileStrengthTD = table.Column<double>(type: "double precision", nullable: false),
                    ElongationAtBreakMD = table.Column<int>(type: "integer", nullable: false),
                    ElongationAtBreakTD = table.Column<int>(type: "integer", nullable: false),
                    CoefficientOfFrictionS = table.Column<double>(type: "double precision", nullable: false),
                    CoefficientOfFrictionD = table.Column<double>(type: "double precision", nullable: false),
                    LightTransmission = table.Column<int>(type: "integer", nullable: false),
                    CoronaTreatment = table.Column<int>(type: "integer", nullable: false),
                    StandartQualityTitleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersQuality", x => x.OrderQualityId);
                    table.ForeignKey(
                        name: "FK_OrdersQuality_Extruders_ExtruderId",
                        column: x => x.ExtruderId,
                        principalTable: "Extruders",
                        principalColumn: "ExtruderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersQuality_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersQuality_StandartQualityTitles_StandartQualityTitleId",
                        column: x => x.StandartQualityTitleId,
                        principalTable: "StandartQualityTitles",
                        principalColumn: "StandartQualityTitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandartQualityFilms",
                columns: table => new
                {
                    StandartQualityFilmId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmId = table.Column<int>(type: "integer", nullable: false),
                    ThicknessVariation = table.Column<double>(type: "double precision", nullable: false),
                    TensileStrengthMD = table.Column<double>(type: "double precision", nullable: false),
                    TensileStrengthTD = table.Column<double>(type: "double precision", nullable: false),
                    ElongationAtBreakMD = table.Column<int>(type: "integer", nullable: false),
                    ElongationAtBreakTD = table.Column<int>(type: "integer", nullable: false),
                    CoefficientOfFrictionS = table.Column<double>(type: "double precision", nullable: false),
                    CoefficientOfFrictionD = table.Column<double>(type: "double precision", nullable: false),
                    LightTransmission = table.Column<int>(type: "integer", nullable: true),
                    CoronaTreatment = table.Column<int>(type: "integer", nullable: false),
                    StandartQualityTitleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandartQualityFilms", x => x.StandartQualityFilmId);
                    table.ForeignKey(
                        name: "FK_StandartQualityFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandartQualityFilms_StandartQualityTitles_StandartQualityT~",
                        column: x => x.StandartQualityTitleId,
                        principalTable: "StandartQualityTitles",
                        principalColumn: "StandartQualityTitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleDtoUserDto",
                columns: table => new
                {
                    RolesRoleId = table.Column<int>(type: "integer", nullable: false),
                    UsersUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleDtoUserDto", x => new { x.RolesRoleId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_RoleDtoUserDto_UserRoles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleDtoUserDto_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extruders_Name",
                table: "Extruders",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_Mark_Thickness_Color",
                table: "Films",
                columns: new[] { "Mark", "Thickness", "Color" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersQuality_ExtruderId",
                table: "OrdersQuality",
                column: "ExtruderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersQuality_FilmId",
                table: "OrdersQuality",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersQuality_StandartQualityTitleId",
                table: "OrdersQuality",
                column: "StandartQualityTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleDtoUserDto_UsersUserId",
                table: "RoleDtoUserDto",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StandartQualityFilms_FilmId_StandartQualityTitleId",
                table: "StandartQualityFilms",
                columns: new[] { "FilmId", "StandartQualityTitleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StandartQualityFilms_StandartQualityTitleId",
                table: "StandartQualityFilms",
                column: "StandartQualityTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_StandartQualityTitles_Title",
                table: "StandartQualityTitles",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersQuality");

            migrationBuilder.DropTable(
                name: "RoleDtoUserDto");

            migrationBuilder.DropTable(
                name: "StandartQualityFilms");

            migrationBuilder.DropTable(
                name: "Extruders");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "StandartQualityTitles");
        }
    }
}
