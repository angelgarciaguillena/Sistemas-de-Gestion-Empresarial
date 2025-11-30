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
        public IActionResult AgregarPersona(PersonaConListadoDepartamento dto, IFormFile FotoFile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    dto.ListadoDepartamentos = _personaUseCase.getDepartamentos();
                    return View(dto);
                }

                if (FotoFile != null && FotoFile.Length > 0)
                {
                    dto.Persona.Foto = FotoFile.FileName;
                }

                _personaUseCase.agregarPersona(dto.Persona);
                return RedirectToAction("IndexPersona");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al crear la persona: " + ex.Message;
                dto.ListadoDepartamentos = _personaUseCase.getDepartamentos();
                return View(dto);
            }
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
        public IActionResult EditarPersona(PersonaConListadoDepartamento dto, IFormFile FotoFile)
        {
            try
            {
                if (dto == null) return BadRequest();

                if (!ModelState.IsValid)
                {
                    dto.ListadoDepartamentos = _personaUseCase.getDepartamentos();
                    return View(dto);
                }

                if (FotoFile != null && FotoFile.Length > 0)
                {
                    dto.Persona.Foto = FotoFile.FileName;
                }

                _personaUseCase.actualizarPersona(dto.Persona);
                return RedirectToAction("IndexPersona");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al actualizar la persona: " + ex.Message;
                dto.ListadoDepartamentos = _personaUseCase.getDepartamentos();
                return View(dto);
            }
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
