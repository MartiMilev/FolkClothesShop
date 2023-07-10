using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FolkClothesShop.Web.ViewModel.Product
{
    public class ProductAllViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Име")]
        public string Title { get; set; } = null!;
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Снимка")]
        public string ImageUrl { get; set; } = null!;
    }
}
