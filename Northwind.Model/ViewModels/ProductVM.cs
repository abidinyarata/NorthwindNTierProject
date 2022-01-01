using System.ComponentModel.DataAnnotations;

namespace Northwind.Model.ViewModels
{
    public abstract class ProductVMM
    {
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [StringLength(40, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        [Display(Name = "Product Name", Prompt = "Enter a product name...")]
        public string ProductName { get; set; }

        [Display(Name = "Unit Price", Prompt = "00.00€")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Units In Stock", Prompt = "0")]
        public short? UnitsInStock { get; set; }
    }
}
