using Microsoft.AspNetCore.Mvc;
using Northwind.Business;
using Northwind.Model.ViewModels;
using System.Collections.Generic;

namespace Northwind.Web.UI.Controllers
{
    public class ProductAsyncController : Controller
    {
        ProductService _productService = new ProductService();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProductPartial()
        {
            List<ListProductVM> products = _productService.GetProducts();
            return PartialView("_productTable", products);
        }
    }
}
