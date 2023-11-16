using CsvHelper;
using MunicipalidadesMVC7.Models;
using System.Formats.Asn1;
using System.Globalization;

namespace MunicipalidadesMVC7.Utilities
{
    public class MunicipalidadFileReader
    {
        public static List<Municipalidad> ReadFromCsv(string filePath)
        {
            var municipalidades = new List<Municipalidad>();

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    municipalidades = csv.GetRecords<Municipalidad>().ToList();
                }
            }
            catch (Exception ex)
            {
                // Registra o maneja la excepción según sea necesario
                Console.WriteLine($"Error al leer el archivo CSV: {ex.Message}");
            }

            return municipalidades;
        }
    }
}
