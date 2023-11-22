using Microsoft.EntityFrameworkCore.Migrations;

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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingresos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gastos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProyectosEjecutados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aprobacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trimestre1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trimestre2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trimestre3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trimestre4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EficienciaGastos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecursosOrdinarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecursosRecaudados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecursosOperaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecursosDeterminados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Donaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            var municipalidadesToAdd = ReadFromTxt("D:\\MunicipalidadesASPdotNET\\wwwroot\\Municipalidades.txt");
            foreach (var nombreMunicipalidad in municipalidadesToAdd)
            {
                migrationBuilder.InsertData(
                    table: "Municipalidades",
                    columns: new[] { "Nombre", "ImagenUrl","Ingresos","Gastos", "ProyectosEjecutados", "Aprobacion", "Trimestre1", "Trimestre2", "Trimestre3", "Trimestre4", "EficienciaGastos", "RecursosOrdinarios", "RecursosRecaudados", "RecursosOperaciones", "RecursosDeterminados", "Donaciones" },
                    values: new object[] {
                        nombreMunicipalidad,
                        "https://pgrlm.gob.pe/wp-content/uploads/sites/30/2022/11/Fachada-de-la-Municipalidad-de-Lima.jpg",
                        "99,749,170",
                        "47,532,683",
                        "30",         // Proyectos ejecutados
                        "50",         // Aprobación
                        "65512522",  // Trimestre 1
                        "72482577",  // Trimestre 2
                        "97372223",  // Trimestre 3
                        "99749170",  // Trimestre 4
                        "55",         // Eficiencia de gastos 
                        "90",        // Recursos ordinarios
                        "95",        // Recursos directamente recaudados
                        "0",         // Recursos por operaciones oficiales
                        "55",         // Recursos determinados
                        "0"         // Donaciones y transferencias
                    });

            }
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "NombreUsuario", "Contrasena" },
                values: new object[] { "admin", "admin" }
                );
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
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Municipalidades");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
