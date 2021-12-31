using Microsoft.AspNetCore.Mvc;
using Northwind.Business;
using Northwind.Model.ViewModels;
using System.Collections.Generic;

namespace Northwind.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductService _productService = new ProductService();

        public IActionResult Index(int id = 0)
        {
            List<ProductVM> products = null;

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
    }
}
