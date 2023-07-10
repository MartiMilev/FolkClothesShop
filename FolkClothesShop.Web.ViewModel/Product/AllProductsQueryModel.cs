using FolkClothesShop.Web.ViewModel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Web.ViewModel.Product
{
    public class AllProductsQueryModel
    {
        public AllProductsQueryModel()
        {
            this.CurrentPage= 1;
            this.ProductPerPage = 16;
            this.Categories = new HashSet<string>();
            this.Products = new HashSet<ProductAllViewModel>();
        }
        public string? Category { get; set; }
        [Display(Name = "Търси")]
        public string? SerarchString { get; set; }
        [Display(Name = "Филтри")]
        public ProductSorting ProductSorting { get; set; }
        public int CurrentPage { get; set; }
        public int TotalProducts { get; set; }
        public int ProductPerPage { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<ProductAllViewModel> Products { get; set; }
    }
}
