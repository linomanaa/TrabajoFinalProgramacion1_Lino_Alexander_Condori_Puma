using System.ComponentModel.DataAnnotations;

namespace MunicipalidadesMVC7.Models
{
    public class Municipalidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ImagenUrl { get; set; }
        [Required]
        public string Ingresos {  get; set; }
        [Required]
        public string Gastos { get; set; }
        public string ProyectosEjecutados { get; set; }
        [Required]
        public string Aprobacion {  get; set; }
        [Required]
        public string Trimestre1 {  get; set; }
        [Required]
        public string Trimestre2 { get; set; }
        [Required]
        public string Trimestre3 { get; set; }
        [Required]
        public string Trimestre4 { get; set; }
        [Required]
        public string EficienciaGastos { get; set; }
        [Required]
        public string RecursosOrdinarios { get; set; }
        [Required]
        public string RecursosRecaudados { get; set; }
        [Required]
        public string RecursosOperaciones { get; set; }
        [Required]
        public string RecursosDeterminados { get; set; }
        [Required]
        public string Donaciones { get; set; }

    }
}
