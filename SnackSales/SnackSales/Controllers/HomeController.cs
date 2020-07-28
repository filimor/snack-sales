using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SnackSales.Models;
using SnackSales.Repositories;
using SnackSales.ViewModels;

namespace SnackSales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISnackRepository _snackRepository;

        public HomeController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                FavoriteSnacks = _snackRepository.FavoriteSnacks
            };

            return View(homeViewModel);
        }

        //TODO: remove Error view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}