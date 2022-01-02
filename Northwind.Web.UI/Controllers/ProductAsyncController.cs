using Microsoft.AspNetCore.Mvc;
using Northwind.Business;
using Northwind.Model.ViewModels;
using System;
using System.Collections.Generic;

namespace Northwind.Web.UI.Controllers
{
    public class ProductAsyncController : Controller
    {
        ProductService _productService = new ProductService();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProductPartial()
        {
            List<ListProductVM> products = _productService.GetProducts();
            return PartialView("_productTable", products);
        }

        public IActionResult GetProductByCategoryPartial(int id)
        {
            List<ListProductVM> products = _productService.GetProductsByCategoryId(id);
            return PartialView("_productTable", products);
        }

        public IActionResult GetProductByProductId(int id)
        {
            AddProductVM product = _productService.GetProductByProductId(id);
            return Json(product);
        }

        public IActionResult AddData(AddProductVM product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = _productService.AddProduct(product);
                    if (check)
                    {
                        return Json("Kayıt Başarılı");
                    }
                    else
                    {
                        return Json("Kayıt işlemi başarısız");
                    }
                }
                else
                {
                    return Json("Verilerinizi kontrol edin");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult UpdateData(UpdateProductVM product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = _productService.UpdateProduct(product);
                    if (check)
                    {
                        return Json("Güncelleme işlemi başarılı");
                    }
                    else
                    {
                        return Json("Güncelleme işlemi başarısız");
                    }
                }
                else
                {
                    return Json("Verilerinizi kontrol edin");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult DeleteData(int id)
        {
            bool check = _productService.DeleteProduct(id);
            if (check)
            {
                return Json("Silme başarılı");
            }
            else
            {
                return Json("Silme başarısız");
            }
        }
    }
}
