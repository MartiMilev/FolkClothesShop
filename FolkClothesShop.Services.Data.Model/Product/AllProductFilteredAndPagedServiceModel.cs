using FolkClothesShop.Web.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Services.Data.Model.Product
{
    public class AllProductFilteredAndPagedServiceModel
    {
        public AllProductFilteredAndPagedServiceModel()
        {
            this.Products = new HashSet<ProductAllViewModel>();
        }
        public int TotalProductCount { get; set; }
        public IEnumerable<ProductAllViewModel> Products { get; set; }
    }
}
