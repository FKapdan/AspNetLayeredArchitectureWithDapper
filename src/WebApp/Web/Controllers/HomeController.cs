﻿using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : AspNetLayeredArchitectureWithDapperBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
