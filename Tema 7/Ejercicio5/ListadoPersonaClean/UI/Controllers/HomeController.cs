using System.Diagnostics;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetListaPersonasUseCase _useCaseListaPersonas;

        public HomeController(ILogger<HomeController> logger, IGetListaPersonasUseCase useCaseListaPersonas)
        {
            _logger = logger;
            _useCaseListaPersonas = useCaseListaPersonas;
        }

        public IActionResult Index()
        {
            return View(_useCaseListaPersonas.getListaPersonas());
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