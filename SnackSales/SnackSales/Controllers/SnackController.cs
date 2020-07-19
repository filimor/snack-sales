using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackSales.Repositories;
using SnackSales.ViewModels;

namespace SnackSales.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackRepository;

        private readonly ICategoryRepository _categoryRepository;

        public SnackController(ISnackRepository snackRepository, ICategoryRepository categoryRepository)
        {
            _snackRepository = snackRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            ViewBag.Snack = "Snacks";
            ViewData["Category"] = "Category";

            var snackListViewModel = new SnackListViewModel();
            snackListViewModel.Snacks = _snackRepository.Snacks;
            snackListViewModel.CurrentCategory = "Current Category";
            return View(snackListViewModel);

        }
    }
}
