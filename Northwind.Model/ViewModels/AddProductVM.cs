using System.ComponentModel.DataAnnotations;

namespace Northwind.Model.ViewModels
{
    public class AddProductVM : ProductVMM
    {
        [Display(Name = "Category Name")]
        public int CategoryId { get; set; }
    }
}
