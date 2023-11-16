using Microsoft.Data.SqlClient;
using MunicipalidadesMVC7.Models;
using System.Data;

namespace MunicipalidadesMVC7.Utilities
{
    public class DatabaseUtilities
    {
        public static void BulkInsertMunicipalidades(List<Municipalidad> municipalidades)
        {
            using (var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=CrudNET7;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (var bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "Municipalidades"; // Nombre de tu tabla

                    var dataTable = new DataTable();
                    dataTable.Columns.Add("Nombre", typeof(string));

                    foreach (var municipalidad in municipalidades)
                    {
                        dataTable.Rows.Add(municipalidad.Nombre);
                    }

                    bulkCopy.WriteToServer(dataTable);
                }
            }
        }

    }
}
