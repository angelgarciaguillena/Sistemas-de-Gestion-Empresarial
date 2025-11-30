using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoUseCase _departamentoUseCase;

        public DepartamentoController(IDepartamentoUseCase departamentoUseCase)
        {
            _departamentoUseCase = departamentoUseCase;
        }

        public IActionResult IndexDepartamento()
        {
            try
            {
                var departamentos = _departamentoUseCase.getDepartamentos();
                return View(departamentos);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar el listado: " + ex.Message;
                return View(new List<Departamento>());
            }
        }

        public IActionResult DetallesDepartamento(int id)
        {
            try
            {
                var departamento = _departamentoUseCase.getDepartamento(id);
                if (departamento == null)
                {
                    ViewBag.Error = "Departamento no encontrado";
                    return RedirectToAction("IndexDepartamento");
                }

                return View(departamento);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar los detalles: " + ex.Message;
                return RedirectToAction("IndexDepartamento");
            }
        }

        public IActionResult AgregarDepartamento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarDepartamento(Departamento departamento)
        {
            try
            {
                _departamentoUseCase.agregarDepartamento(departamento);
                return RedirectToAction("IndexDepartamento");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al crear el departamento: " + ex.Message;
                return View(departamento);
            }
        }

        public IActionResult EditarDepartamento(int id)
        {
            try
            {
                var departamento = _departamentoUseCase.getDepartamento(id);
                if (departamento == null)
                {
                    ViewBag.Error = "Departamento no encontrado";
                    return RedirectToAction("IndexDepartamento");
                }
                return View(departamento);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar el formulario: " + ex.Message;
                return RedirectToAction("IndexDepartamento");
            }
        }

        [HttpPost]
        public IActionResult EditarDepartamento(Departamento departamento)
        {
            try
            {
                _departamentoUseCase.actualizarDepartamento(departamento);
                return RedirectToAction("IndexDepartamento");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al actualizar el departamento: " + ex.Message;
                return View(departamento);
            }
        }

        public IActionResult EliminarDepartamento(int id)
        {
            try
            {
                var departamento = _departamentoUseCase.getDepartamento(id);
                if (departamento == null)
                {
                    ViewBag.Error = "Departamento no encontrado";
                    return RedirectToAction("IndexDepartamento");
                }

                return View(departamento);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar los datos: " + ex.Message;
                return RedirectToAction("IndexDepartamento");
            }
        }

        [HttpPost]
        public IActionResult EliminarDepartamentoConfirmado(int id)
        {
            try
            {
                _departamentoUseCase.eliminarDepartamento(id);
                return RedirectToAction("IndexDepartamento");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar el departamento: " + ex.Message;
                return View("IndexDepartamento");
            }
        }
    }
}
