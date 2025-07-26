using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrudProyect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Activo", "Apellido", "Cargo", "Email", "FechaContratacion", "Nombre", "Salario", "Telefono" },
                values: new object[,]
                {
                    { 1, true, "Pérez", "Desarrollador", "juan.perez@empresa.com", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", 3500.00m, "987654321" },
                    { 2, true, "García", "Analista", "maria.garcia@empresa.com", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", 3000.00m, "987654322" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Email",
                table: "Empleados",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
