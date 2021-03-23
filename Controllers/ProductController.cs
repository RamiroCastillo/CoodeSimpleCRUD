using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoodeSimpleCRUD.Data;
using CoodeSimpleCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoodeSimpleCRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly CodeSimpleContex _contex;

        public ProductController(CodeSimpleContex contex)
        {
            _contex = contex;
        }
        public IActionResult Index()
        {
            List<Product> products = _contex.Products.ToList();
            return View(products);
        }

        public IActionResult IndexAjax()
        {
            List<Product> products = _contex.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _contex.Add(product);
            _contex.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(string Id)
        {
            Product product = _contex.Products.Where(p => p.Code == Id).FirstOrDefault();
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            Product product = _contex.Products.Where(p => p.Code == Id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _contex.Attach(product);
            _contex.Entry(product).State = EntityState.Modified;
            _contex.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            Product product = _contex.Products.Where(p => p.Code == Id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _contex.Attach(product);
            _contex.Entry(product).State = EntityState.Deleted;
            _contex.SaveChanges();
            return RedirectToAction("index");
        }

        #region "Ajax functions"

        [HttpPost]
        public IActionResult DeleteProduct(string Id)
        {
            Product product = _contex.Products.Where(p => p.Code == Id).FirstOrDefault();
            _contex.Entry(product).State = EntityState.Deleted;
            _contex.SaveChanges();
            return Ok();
        }

        public IActionResult ViewProduct(string Id)
        {
            Product product = _contex.Products.Where(p => p.Code == Id).FirstOrDefault();
            return PartialView("_Detail",product);
        }

        public IActionResult EditProduct(string Id)
        {
            Product product = _contex.Products.Where(p => p.Code == Id).FirstOrDefault();
            return PartialView("_Edit", product);
        }

        public IActionResult UpdateProduct(Product product)
        {
            _contex.Attach(product);
            _contex.Entry(product).State = EntityState.Modified;
            _contex.SaveChanges();
            return PartialView("_Product", product);

        }

        #endregion
    }
}
