using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalidadesMVC7.Data;
using MunicipalidadesMVC7.Models;
using System.Diagnostics;

namespace MunicipalidadesMVC7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Municipalidades.ToListAsync());
        }
        public async Task<IActionResult> Login(int municipalidadId)
        {
            // Obtén la información de la municipalidad según el ID
            var municipalidad = await _context.Municipalidades.FindAsync(municipalidadId);

            if (municipalidad == null)
            {
                // Si no se encuentra la municipalidad, puedes manejar el error de alguna manera
                return NotFound();
            }

            // Carga la lista completa de usuarios
            var usuarios = await _context.Usuarios.ToListAsync();

            // Pasa la municipalidad y la lista de usuarios a la vista
            ViewData["Municipalidad"] = municipalidad;
            return View(usuarios);
        }

        public async Task<IActionResult> Dashboard(int municipalidadId, string username, string password)
        {
            if (IsValidUser(username, password))
            {
                ViewData["MunicipalidadId"] = municipalidadId;
                return View();
            }
            else
            {
                // Manejar el caso en el que las credenciales no son válidas
                return RedirectToAction("Login", new { municipalidadId });
            }
        }
        private bool IsValidUser(string username, string password)
        {
            // Busca el usuario en la base de datos
            var user = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == username && u.Contrasena == password);

            // Retorna true si el usuario es encontrado
            return user != null;
        }

    }
}
