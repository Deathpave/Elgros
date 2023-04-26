﻿using Elgros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Elgros.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            return View();
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