using FolkClothesShop.Web.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<ProductSelectViewModel>> AllCategoriesAsync();
    }
}
