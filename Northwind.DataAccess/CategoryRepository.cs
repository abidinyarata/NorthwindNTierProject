using Northwind.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.DataAccess
{
    public class CategoryRepository
    {
        NorthwindDBContext _dbContext = new NorthwindDBContext();

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
