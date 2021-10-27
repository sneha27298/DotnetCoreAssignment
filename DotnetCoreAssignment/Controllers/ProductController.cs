using Bogus;
using DotnetCoreAssignment.Models;
using DotnetCoreAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreAssignment.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductsDb products = new ProductsDb();
            return View(products.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            ProductsDb products = new ProductsDb();

            List<ProductModel> productList = products.SearchProducts(searchTerm);
            return View("index", productList);
        }

        public IActionResult SearchForm()
        {
            return View();
        }
        public IActionResult Message()
        {
            return View("message");
        }

        public IActionResult Welcome(string name, int secretNumber=27)
        {
            ViewBag.Name = name;
            ViewBag.Secret = secretNumber;
            return View();
        }
    }
}
