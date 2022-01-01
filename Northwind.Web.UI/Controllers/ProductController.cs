using Microsoft.AspNetCore.Mvc;
using Northwind.Business;
using Northwind.Model.ViewModels;
using System;
using System.Collections.Generic;

namespace Northwind.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductService _productService = new ProductService();

        public IActionResult Index(int id = 0)
        {
            List<ListProductVM> products = null;

            if (id == 0)
            {
                products = _productService.GetProducts();
            }
            else
            {
                products = _productService.GetProductsByCategoryId(id);
            }

            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductVM product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = _productService.AddProduct(product);
                    if (check)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["Message"] = "Kayıt Başarısız";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }

            return View(product);
        }
    }
}
