using Northwind.DataAccess;
using Northwind.Entities;
using Northwind.Model.ViewModels;
using System.Collections.Generic;

namespace Northwind.Business
{
    public class ProductService
    {
        ProductRepository _productRepository = new ProductRepository();

        public List<ListProductVM> GetProducts()
        {
            List<Product> products = _productRepository.GetProducts();
            List<ListProductVM> viewProducts = SetProductView(products);
            return viewProducts;
        }

        private static List<ListProductVM> SetProductView(List<Product> products)
        {
            List<ListProductVM> viewProducts = new List<ListProductVM>();

            ListProductVM productVM;
            foreach (Product product in products)
            {
                productVM = new ListProductVM
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

        public List<ListProductVM> GetProductsByCategoryId(int id)
        {
            List<Product> productsByCategory = _productRepository.GetProductsByCategoryId(id);
            List<ListProductVM> viewProductsByCategory = SetProductView(productsByCategory);
            return viewProductsByCategory;
        }
    }
}
