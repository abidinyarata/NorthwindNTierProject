using Microsoft.AspNetCore.Mvc;
using Northwind.Business;
using Northwind.Model.ViewModels;
using System.Collections.Generic;

namespace Northwind.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductService _productService = new ProductService();

        public IActionResult Index()
        {
            List<ProductVM> products = _productService.GetProducts();
            return View(products);
        }
    }
}
