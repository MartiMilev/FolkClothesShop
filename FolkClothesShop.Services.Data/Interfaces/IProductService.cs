﻿using FolkClothesShop.Services.Data.Model.Product;
using FolkClothesShop.Web.ViewModel.Home;
using FolkClothesShop.Web.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<IndexViewModel>>AllProductsAsync();
        Task CreateAsync(ProductFormModel formModel, string adminId);
        Task<AllProductFilteredAndPagedServiceModel> AllAsync(AllProductsQueryModel queryModel);
        Task<ProductDetailsViewModel?> GetByIdDetailsAsync(string productId);
    }
}
