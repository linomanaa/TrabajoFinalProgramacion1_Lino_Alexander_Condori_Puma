using System.ComponentModel.DataAnnotations;

namespace MunicipalidadesMVC7.Models
{
    public class Municipalidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
