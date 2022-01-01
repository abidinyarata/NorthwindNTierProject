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

        public int Insert(Product product)
        {
            _dbContext.Products.Add(product);
            return _dbContext.SaveChanges();
        }

        public Product GetProductByProductId(int id)
        {
            return _dbContext.Products.SingleOrDefault(p => p.ProductId == id);
        }

        public int Update(Product product)
        {
            Product oldProduct = GetProductByProductId(product.ProductId);
            oldProduct.ProductName = product.ProductName;
            oldProduct.CategoryId = product.CategoryId;
            oldProduct.UnitsInStock = product.UnitsInStock;
            oldProduct.UnitPrice = product.UnitPrice;

            return _dbContext.SaveChanges();
        }
    }
}
