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

        public IActionResult ShowDetails(int id)
        {
            ProductsDb products = new ProductsDb();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }
        public IActionResult Edit(int id)
        {
            ProductsDb products = new ProductsDb();
            ProductModel foundProduct = products.GetProductById(id);
            return View("Edit", foundProduct);
        }
        public IActionResult Delete(int id)
        {
            ProductsDb products = new ProductsDb();
            ProductModel product = products.GetProductById(id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }
        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDb products = new ProductsDb();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        public IActionResult ProcessCreate(ProductModel product)
        {
            ProductsDb products = new ProductsDb();
            products.Insert(product);
            return View("Index", products.GetAllProducts());
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
