using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQualityMonitoringSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SensoresCalidadAire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ubicacion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoGas = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensoresCalidadAire", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlertasAire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mensaje = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaHora = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertasAire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertasAire_SensoresCalidadAire_SensorId",
                        column: x => x.SensorId,
                        principalTable: "SensoresCalidadAire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LecturasAire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    PM2_5 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PM10 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CO2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturasAire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturasAire_SensoresCalidadAire_SensorId",
                        column: x => x.SensorId,
                        principalTable: "SensoresCalidadAire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlertasAire_SensorId",
                table: "AlertasAire",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturasAire_SensorId",
                table: "LecturasAire",
                column: "SensorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertasAire");

            migrationBuilder.DropTable(
                name: "LecturasAire");

            migrationBuilder.DropTable(
                name: "SensoresCalidadAire");
        }
    }
}
