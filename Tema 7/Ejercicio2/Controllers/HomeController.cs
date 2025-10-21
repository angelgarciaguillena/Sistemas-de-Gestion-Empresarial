using System.Diagnostics;
using Ejercicio2.Models;
using Microsoft.AspNetCore.Mvc;
using Ejercicio2.Models.DAL;

namespace Ejercicio2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListadoPersonas()
        {
            // crear una lista de personas
            var personas = new List<clsPersona>
            {
                new clsPersona(1, "Paco", "Porras", 30),
                new clsPersona(2, "María", "Gómez", 25),
                new clsPersona(3, "Luis", "Rodríguez", 40),
                new clsPersona(4, "Ana", "López", 35),
                new clsPersona(5, "Carlos", "Sánchez", 28),
                new clsPersona(6, "Laura", "Martínez", 32)
            };

            // pasar la lista de personas a la vista
            return View(personas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}