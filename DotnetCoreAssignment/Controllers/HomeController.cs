using DotnetCoreAssignment.Models;
using DotnetCoreAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreAssignment.Controllers
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
            ViewBag.Slogan = "We're here to serve only the best products for you...";
            ViewBag.Slogan1 = "Search no more!, Contact Us..";
            ViewBag.Loc = "Grocery Store, #1111/a, Random Road";
            ViewBag.Loc1 = "Mysore, Karnataka - 570001";
            ViewBag.Phone = "9876543210";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
