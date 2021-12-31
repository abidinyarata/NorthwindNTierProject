using Northwind.DataAccess;
using Northwind.Entities;
using Northwind.Model.ViewModels;
using System.Collections.Generic;

namespace Northwind.Business
{
    public class ProductService
    {
        ProductRepository _productRepository = new ProductRepository();

        public List<ProductVM> GetProducts()
        {
            List<Product> products = _productRepository.GetProducts();
            List<ProductVM> viewProducts = new List<ProductVM>();

            ProductVM productVM;
            foreach (Product product in products)
            {
                productVM = new ProductVM
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock
                };
                viewProducts.Add(productVM);
            }

            return viewProducts;
        }
    }
}
