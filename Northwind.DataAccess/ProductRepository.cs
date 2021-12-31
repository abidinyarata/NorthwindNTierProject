using Northwind.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.DataAccess
{
    public class ProductRepository
    {
        NorthwindDBContext _dbContext = new NorthwindDBContext();

        public List<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            return _dbContext.Products.Where(p => p.CategoryId == id).ToList();
        }
    }
}
