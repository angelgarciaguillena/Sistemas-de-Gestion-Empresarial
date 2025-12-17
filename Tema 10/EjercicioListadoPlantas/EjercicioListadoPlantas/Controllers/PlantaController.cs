using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using Domain.Interfaces;
using Domain.DTOs;

namespace UI.Controllers
{
    
    public class PlantaController : Controller
    {
        private readonly IPlantaUseCase _plantaUseCase;

        public PlantaController(IPlantaUseCase plantaUseCase)
        {
            this._plantaUseCase = plantaUseCase;
        }

        // GET: /Planta/Index
        public ActionResult Index()
        {
            ListadoCategoriasConListadoPlantas modelo = this._plantaUseCase.GetListadoCategoriasConListadoPlantas(null);
            return View(modelo);
        }

        // POST: /Planta/Index
        [HttpPost]
        public ActionResult Index(int idCategoria)
        {
            ListadoCategoriasConListadoPlantas modelo = this._plantaUseCase.GetListadoCategoriasConListadoPlantas(idCategoria);
            return View(modelo);
        }

        // GET: /Planta/Update/{idPlanta}
        public ActionResult Update(int idPlanta)
        {
            PlantaConNombreCategoria modelo = this._plantaUseCase.GetPlantaConNombreCategoria(idPlanta);
            return View(modelo);
        }

        // POST: /Planta/Update
        [HttpPost]
        public ActionResult Update(int idPlanta, double nuevoPrecio)
        {
            int resultado = this._plantaUseCase.UpdatePrecioPlanta(idPlanta, nuevoPrecio);

            PlantaConNombreCategoria modelo = this._plantaUseCase.GetPlantaConNombreCategoria(idPlanta);

            if (resultado == 0)
            {
                ViewBag.Error = "El nuevo precio debe ser mayor al precio actual.";
            }
            else
            {
                ViewBag.Success = "Precio actualizado correctamente.";
            }

            return View(modelo);
        }
    }
}
