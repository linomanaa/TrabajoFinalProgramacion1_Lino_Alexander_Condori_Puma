using CsvHelper;
using Microsoft.EntityFrameworkCore.Migrations;
using MunicipalidadesMVC7.Utilities;
using System.Globalization;

#nullable disable

namespace MunicipalidadesMVC7.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            var municipalidadesToAdd = ReadFromTxt("D:\\MunicipalidadesMVC7\\MunicipalidadesMVC7\\wwwroot\\Municipalidades.txt");

            foreach (var nombreMunicipalidad in municipalidadesToAdd)
            {
                migrationBuilder.InsertData(
                    table: "Municipalidades",
                    columns: new[] { "Nombre" },
                    values: new object[] { nombreMunicipalidad });
            }


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Municipalidades");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
        private List<string> ReadFromTxt(string filePath)
        {
            var result = new List<string>();

            try
            {
                // Lee todas las líneas del archivo de texto
                var lines = File.ReadAllLines(filePath);

                // Agrega cada línea a la lista de resultados
                result.AddRange(lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo de texto: {ex.Message}");
            }

            return result;
        }
    }
}