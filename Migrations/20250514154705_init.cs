using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personer",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobilnummer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Epost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personer", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Arbetserfarenheter",
                columns: table => new
                {
                    ArbetserfarenhetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Företag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Jobbtitel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Jobbbeskrivning = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Jobbstart = table.Column<DateOnly>(type: "date", nullable: false),
                    Jobbslut = table.Column<DateOnly>(type: "date", nullable: false),
                    PerosonID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbetserfarenheter", x => x.ArbetserfarenhetID);
                    table.ForeignKey(
                        name: "FK_Arbetserfarenheter_Personer_PerosonID_FK",
                        column: x => x.PerosonID_FK,
                        principalTable: "Personer",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utbildningar",
                columns: table => new
                {
                    UtbildningID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skola = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UtbildningBeskrivning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UtbildningExamen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtbildningStart = table.Column<DateOnly>(type: "date", nullable: false),
                    UtbildningSlut = table.Column<DateOnly>(type: "date", nullable: false),
                    PersonId_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utbildningar", x => x.UtbildningID);
                    table.ForeignKey(
                        name: "FK_Utbildningar_Personer_PersonId_FK",
                        column: x => x.PersonId_FK,
                        principalTable: "Personer",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arbetserfarenheter_PerosonID_FK",
                table: "Arbetserfarenheter",
                column: "PerosonID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Utbildningar_PersonId_FK",
                table: "Utbildningar",
                column: "PersonId_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbetserfarenheter");

            migrationBuilder.DropTable(
                name: "Utbildningar");

            migrationBuilder.DropTable(
                name: "Personer");
        }
    }
}
