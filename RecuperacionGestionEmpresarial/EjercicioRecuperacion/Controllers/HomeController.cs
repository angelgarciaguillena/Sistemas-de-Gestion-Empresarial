using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using EjercicioRecuperacion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Mappers;
using UI.Models;

namespace EjercicioRecuperacion.Controllers
{
    /// <summary>
    /// Controlador principal que gestiona la lógica de la aplicación de juego de departamentos
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Caso de uso de personas
        /// </summary>
        private readonly IPersonaUseCase _personaUseCase;

        /// <summary>
        /// Mapper de la capa Domain a la capa UI
        /// </summary>
        private readonly IDomainToUI _mapper;

        /// <summary>
        /// Constructor que inyecta las dependencias necesarias
        /// </summary>
        /// <param name="personaUseCase">Caso de uso de personas</param>
        /// <param name="mapper">Mapper de dominio a UI</param>
        public HomeController(IPersonaUseCase personaUseCase, IDomainToUI mapper)
        {
            _personaUseCase = personaUseCase;
            _mapper = mapper;
        }

        /// <summary>
        /// Acción GET que muestra la vista inicial del juego con la lista de personas
        /// </summary>
        /// <returns>Vista con el listado de personas</returns>
        public IActionResult Index()
        {
            List<PersonaConListadoDepartamento> personasDomain = _personaUseCase.getPersonas();
            List<PersonaConColor> personasUI = personasDomain.Select(p => _mapper.transformar(p)).ToList();

            ViewBag.Resultado = null;
            ViewBag.TotalPersonas = personasUI.Count;
            ViewBag.SeleccionesAnteriores = null;

            return View(personasUI);
        }

        /// <summary>
        /// Acción POST que procesa la comprobación de departamentos seleccionados por el usuario
        /// </summary>
        /// <param name="departamentosSeleccionados">Lista de IDs de departamentos seleccionados por el usuario</param>
        /// <returns>Vista con el resultado de la comprobación</returns>
        [HttpPost]
        public IActionResult Index(List<int?> departamentosSeleccionados)
        {
            List<PersonaConListadoDepartamento> personasDomain = _personaUseCase.getPersonas();
            List<PersonaConColor> personasUI = personasDomain.Select(p => _mapper.transformar(p)).ToList();
            ViewBag.TotalPersonas = personasDomain.Count;

            if (departamentosSeleccionados == null || departamentosSeleccionados.Count != personasDomain.Count || departamentosSeleccionados.Any(d => !d.HasValue || d.Value == 0))
            {
                ViewBag.Resultado = "Debes seleccionar un departamento para todos los empleados antes de comprobar las asignaciones.";
                ViewBag.TipoResultado = "validacion";
                ViewBag.SeleccionesAnteriores = departamentosSeleccionados;
                return View(personasUI);
            }

            List<PersonaConDepartamentoSeleccionado> personasSeleccionadas = new List<PersonaConDepartamentoSeleccionado>();

            for (int i = 0; i < personasDomain.Count; i++)
            {
                int departamentoId = departamentosSeleccionados[i].Value;
                Departamento departamento = personasDomain[i].ListadoDepartamentos.FirstOrDefault(d => d.Id == departamentoId);

                if (departamento != null)
                {
                    personasSeleccionadas.Add(new PersonaConDepartamentoSeleccionado(personasDomain[i].Persona, departamento));
                }
            }

            int aciertos = _personaUseCase.comprobarAciertos(personasSeleccionadas);
            int totalPersonas = personasDomain.Count;

            if (aciertos == totalPersonas)
            {
                ViewBag.Resultado = "¡Enhorabuena! ¡Has acertado todos los departamentos correctamente!";
                ViewBag.TipoResultado = "victoria";
            }
            else
            {
                ViewBag.Resultado = $"Has acertado {aciertos} de {totalPersonas} departamentos. ¡Inténtalo de nuevo!";
                ViewBag.TipoResultado = "intento";
                ViewBag.SeleccionesAnteriores = departamentosSeleccionados;
            }

            return View(personasUI);
        }

        /// <summary>
        /// Devuelve la vista de privacidad.
        /// </summary>
        /// <returns>Vista Privacy</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Devuelve la vista de error con el identificador de solicitud para diagnóstico.
        /// </summary>
        /// <returns>Vista Error</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}