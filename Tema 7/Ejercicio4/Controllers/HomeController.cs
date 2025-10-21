using System.Diagnostics;
using Ejercicio4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4.Controllers
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

        public IActionResult EditarPersona()
        {
            var personas = Models.DAL.clsPersonaDAL.ObtenerPersonas();
            var departamentos = Models.DAL.clsDepartamentoDAL.ObtenerDepartamentos();

            Random rand = new Random();
            var personaAleatoria = personas[rand.Next(personas.Count)];

            ViewBag.Departamentos = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(departamentos, "IdDepartamento", "NombreDepartamento", personaAleatoria.Departamento?.IdDepartamento);

            return View(personaAleatoria);
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
