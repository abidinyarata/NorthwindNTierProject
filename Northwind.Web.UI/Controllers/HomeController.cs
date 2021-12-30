using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
