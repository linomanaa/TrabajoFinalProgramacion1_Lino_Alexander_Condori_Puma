using Microsoft.EntityFrameworkCore;
using MunicipalidadesMVC7.Models;

namespace MunicipalidadesMVC7.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                
        }
        //Agregar aqui los modelos
        public DbSet<Municipalidad> Municipalidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
