using Northwind.DataAccess;
using Northwind.Entities;
using Northwind.Model.ViewModels;
using System;
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

        public bool AddProduct(AddProductVM productVM)
        {
            // İş kuralları uygulanır
            if (productVM.UnitPrice < 0)
            {
                throw new Exception("UnitPrice 0'dan küçük olamaz");
            }

            if (productVM.UnitsInStock < 0)
            {
                throw new Exception("UnitsInStock 0'dan küçük olamaz");
            }

            Product product = new Product
            {
                CategoryId = productVM.CategoryId,
                ProductName = productVM.ProductName,
                UnitPrice = productVM.UnitPrice,
                UnitsInStock = productVM.UnitsInStock
            };

            return _productRepository.Insert(product) > 0;
        }

        public AddProductVM GetProductByProductId(int id)
        {
            Product product = _productRepository.GetProductByProductId(id);
            AddProductVM productVM = new AddProductVM
            {
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            };

            return productVM;
        }

        public bool UpdateProduct(UpdateProductVM productVM)
        {
            if (productVM.UnitPrice < 0)
            {
                throw new Exception("UnitPrice 0'dan küçük olamaz");
            }

            if (productVM.UnitsInStock < 0)
            {
                throw new Exception("UnitsInStock 0'dan küçük olamaz");
            }

            Product product = new Product
            {
                ProductId = productVM.ProductId,
                CategoryId = productVM.CategoryId,
                ProductName = productVM.ProductName,
                UnitPrice = productVM.UnitPrice,
                UnitsInStock = productVM.UnitsInStock
            };

            return _productRepository.Update(product) > 0;
        }
    }
}
