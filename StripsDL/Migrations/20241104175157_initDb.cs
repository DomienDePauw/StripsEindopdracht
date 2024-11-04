using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StripsDL.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAdres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reeksen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reeksen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uitgeverijen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitgeverijen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Strips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UitgeverijId = table.Column<int>(type: "int", nullable: false),
                    ReeksId = table.Column<int>(type: "int", nullable: false),
                    ReeksNummer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Strips_Reeksen_ReeksId",
                        column: x => x.ReeksId,
                        principalTable: "Reeksen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Strips_Uitgeverijen_UitgeverijId",
                        column: x => x.UitgeverijId,
                        principalTable: "Uitgeverijen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuteurStrip",
                columns: table => new
                {
                    AuteursId = table.Column<int>(type: "int", nullable: false),
                    StripsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuteurStrip", x => new { x.AuteursId, x.StripsId });
                    table.ForeignKey(
                        name: "FK_AuteurStrip_Auteurs_AuteursId",
                        column: x => x.AuteursId,
                        principalTable: "Auteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuteurStrip_Strips_StripsId",
                        column: x => x.StripsId,
                        principalTable: "Strips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuteurStrip_StripsId",
                table: "AuteurStrip",
                column: "StripsId");

            migrationBuilder.CreateIndex(
                name: "IX_Strips_ReeksId",
                table: "Strips",
                column: "ReeksId");

            migrationBuilder.CreateIndex(
                name: "IX_Strips_UitgeverijId",
                table: "Strips",
                column: "UitgeverijId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuteurStrip");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Strips");

            migrationBuilder.DropTable(
                name: "Reeksen");

            migrationBuilder.DropTable(
                name: "Uitgeverijen");
        }
    }
}
