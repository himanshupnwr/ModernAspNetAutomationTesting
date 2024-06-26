﻿using Microsoft.AspNetCore.Mvc;
using ProductWebApp.Models;
using System.Diagnostics;

namespace ProductWebApp.Controllers
{
    public class HomeController : Controller
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

        //public IActionResult Demo()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> Product()
        //{
        //    var productClient = new SwaggerClient("https://localhost:44334", new HttpClient());

        //    var result = await productClient.GetProductsAsync();

        //    return View(result);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}