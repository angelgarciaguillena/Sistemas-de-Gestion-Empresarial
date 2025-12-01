using Domain.Entities;
using Domain.Interfaces;
using Domain.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaUseCase _personaUseCase;

        public PersonaController(IPersonaUseCase personaUseCase)
        {
            _personaUseCase = personaUseCase;
        }

        public IActionResult IndexPersona()
        {
            try
            {
                var personas = _personaUseCase.getPersonas();
                return View(personas);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar el listado: " + ex.Message;
                return View(new List<PersonaConNombreDepartamento>());
            }
        }

        public IActionResult DetallesPersona(int id)
        {
            try
            {
                var personaDto = _personaUseCase.getPersona(id);

                if (personaDto == null)
                {
                    ViewBag.Error = "Persona no encontrada";
                    return View();
                }

                return View(personaDto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar los detalles: " + ex.Message;
                return View();
            }
        }

        public IActionResult AgregarPersona()
        {
            try
            {
                var dto = _personaUseCase.getPersonaAgregar();
                return View(dto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar el formulario: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarPersona([Bind(Prefix = "Persona")] Persona persona, IFormFile FotoFile)
        {
            if (persona == null) persona = new Persona();

            if (!ModelState.IsValid)
            {
                var fechaRaw = Request.Form["Persona.FechaNacimiento"].ToString();
                if (!string.IsNullOrWhiteSpace(fechaRaw) && DateTime.TryParse(fechaRaw, out var fecha))
                {
                    persona.FechaNacimiento = fecha;
                    ModelState.Remove("Persona.FechaNacimiento");
                }
            }

            if (!ModelState.IsValid)
            {
                var dtoErr = new PersonaConListadoDepartamento(persona, _personaUseCase.getDepartamentos());
                return View(dtoErr);
            }

            if (FotoFile != null && FotoFile.Length > 0)
            {
                persona.Foto = FotoFile.FileName;
            }

            var filas = _personaUseCase.agregarPersona(persona);
            if (filas <= 0)
            {
                ModelState.AddModelError(string.Empty, "No se ha añadido la persona.");
                var dtoErr = new PersonaConListadoDepartamento(persona, _personaUseCase.getDepartamentos());
                return View(dtoErr);
            }

            return RedirectToAction("IndexPersona");
        }

        public IActionResult EditarPersona(int id)
        {
            try
            {
                var dto = _personaUseCase.getPersonaEditar(id);

                if (dto == null || dto.Persona == null)
                {
                    ViewBag.Error = "Persona no encontrada";
                    return RedirectToAction("IndexPersona");
                }

                return View(dto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar el formulario: " + ex.Message;
                return RedirectToAction("IndexPersona");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarPersona([Bind(Prefix = "Persona")] Persona persona, IFormFile FotoFile)
        {
            if (persona == null) return BadRequest();

            if (!ModelState.IsValid)
            {
                var dtoErr = new PersonaConListadoDepartamento(persona, _personaUseCase.getDepartamentos());
                return View(dtoErr);
            }

            if (FotoFile != null && FotoFile.Length > 0)
            {
                persona.Foto = FotoFile.FileName;
            }

            var filas = _personaUseCase.actualizarPersona(persona);
            if (filas <= 0)
            {
                ModelState.AddModelError(string.Empty, "No se ha actualizado la persona (id quizá incorrecto).");
                var dtoErr = new PersonaConListadoDepartamento(persona, _personaUseCase.getDepartamentos());
                return View(dtoErr);
            }

            return RedirectToAction("IndexPersona");
        }

        public IActionResult EliminarPersona(int id)
        {
            try
            {
                var personaDto = _personaUseCase.getPersona(id);

                if (personaDto == null)
                {
                    ViewBag.Error = "Persona no encontrada";
                    return RedirectToAction("IndexPersona");
                }

                return View(personaDto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar los datos: " + ex.Message;
                return RedirectToAction("IndexPersona");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarPersonaConfirmado(int id)
        {
            try
            {
                _personaUseCase.eliminarPersona(id);
                return RedirectToAction("IndexPersona");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar la persona: " + ex.Message;
                var personaDto = _personaUseCase.getPersona(id);
                return View("EliminarPersona", personaDto);
            }
        }
    }
}
