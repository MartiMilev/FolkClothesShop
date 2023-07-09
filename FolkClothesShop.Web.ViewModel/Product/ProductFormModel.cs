using FolkClothesShop.Web.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Web.ViewModel.Product
{
    public class ProductFormModel
    {
        public ProductFormModel()
        {
            this.Categories = new HashSet<ProductSelectViewModel>();
        }
        [Required]
        [StringLength(50,MinimumLength =5)]
        [Display(Name ="Име")]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(500,MinimumLength =10)]
        [Display(Name ="Описание")]
        public string Description { get; set; } = null!;
        [Required]
        [Display(Name ="Цена")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name ="Снимка")]
        public string ImageUrl { get; set; } = null!;
        [Display(Name ="Категория")]
        public int CategoryId { get; set; }
        public IEnumerable<ProductSelectViewModel> Categories { get; set; }
    }
}
