using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchesMac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutosRepository  _produtosRepository;

        public HomeController(ILogger<HomeController> logger, IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel() 
            {
                ProdutosPreferidos = _produtosRepository.ProdutosPreferidos
            };

            return View(homeViewModel);
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