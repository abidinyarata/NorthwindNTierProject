using Northwind.DataAccess;
using Northwind.Entities;
using Northwind.Model.ComponentVM;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Business
{
    public class CategoryService
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        public List<CategoryVM> GetCategories()
        {
            List<Category> categories = _categoryRepository.GetCategories();
            List<CategoryVM> viewCategories = new List<CategoryVM>();

            CategoryVM categoryVM;
            foreach (Category category in categories)
            {
                categoryVM = new CategoryVM
                {
                    CategoryID = category.CategoryId,
                    CategoryName = category.CategoryName
                };
                viewCategories.Add(categoryVM);
            }

            return viewCategories.OrderBy(c => c.CategoryName).ToList();
        }
    }
}
