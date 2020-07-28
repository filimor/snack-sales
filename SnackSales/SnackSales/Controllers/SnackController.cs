using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnackSales.Models;
using SnackSales.Repositories;
using SnackSales.ViewModels;

namespace SnackSales.Controllers
{
    public class SnackController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISnackRepository _snackRepository;

        public SnackController(ISnackRepository snackRepository, ICategoryRepository categoryRepository)
        {
            _snackRepository = snackRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Snack> snacks;
            var currentCatetory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                snacks = _snackRepository.Snacks.OrderBy(s => s.Id);
                currentCatetory = "Todos os Lanches";
            }
            else
            {
                snacks = string.Equals(_category, "Comum", StringComparison.OrdinalIgnoreCase)
                    ? _snackRepository.Snacks.Where(s => s.Category.Name.Equals("Comum")).OrderBy(s => s.Name)
                    : _snackRepository.Snacks.Where(s => s.Category.Equals("Natural")).OrderBy(s => s.Name);

                currentCatetory = _category;
            }

            var snackListViewModel = new SnackListViewModel
            {
                Snacks = snacks,
                CurrentCategory = currentCatetory
            };
            return View(snackListViewModel);
        }

        public IActionResult Details(int snackId)
        {
            var snack = _snackRepository.Snacks.FirstOrDefault(s => s.Id == snackId);
            //TODO: Error page
            return snack == null ? View("Error") : View(snack);
        }

        public IActionResult Search(string searchString)
        {
            IEnumerable<Snack> snacks;
            var currentCategory = string.Empty;

            snacks = string.IsNullOrEmpty(searchString)
                ? _snackRepository.Snacks.OrderBy(s => s.Id)
                : _snackRepository.Snacks.Where(s =>
                    s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));

            return View("List", new SnackListViewModel
            {
                Snacks = snacks,
                CurrentCategory = "Todos os lanches"
            });
        }
    }
}