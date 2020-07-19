﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackSales.Repositories;

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

            var snacks = _snackRepository.Snacks;
            return View(snacks);
        }
    }
}