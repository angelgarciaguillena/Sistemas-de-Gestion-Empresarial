using Microsoft.AspNetCore.Mvc;
using Ejercicio1.Models.Entities;

namespace TuProyecto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Obtener la hora actual
            var hora = DateTime.Now.Hour;

            // Creamos la variable que almacena el saludo
            string saludo;

            // Creamos el objeto persona
            Persona persona;

            if (hora < 12)
                saludo = "Buenos d�as";
            else if (hora < 20)
                saludo = "Buenas tardes";
            else
                saludo = "Buenas noches";

            // Guardar en ViewData
            ViewData["Saludo"] = saludo;

            // Guardar en ViewBag
            ViewBag.FechaActual = DateTime.Now.ToLongDateString();

            // Crear el objeto persona
            persona = new Persona
            {
                nombre = "Juan",
                apellidos = "P�rez G�mez",
                edad = 30
            };

            // Pasar el modelo a la vista
            return View(persona);
        }
    }
}