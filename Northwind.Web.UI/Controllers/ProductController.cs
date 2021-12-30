using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
