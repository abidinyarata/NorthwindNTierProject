using Microsoft.AspNetCore.Mvc;
using Northwind.Business;
using Northwind.Model.ComponentVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Web.UI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        CategoryService _categoryService = new CategoryService();

        public async Task<IViewComponentResult> InvokeAsync(string toolTip)
        {
            List<CategoryVM> categories = _categoryService.GetCategories();
            if (toolTip == "navbar")
                return View("_navbar", categories);

            return View("_comboBox", categories);
        }
    }
}
