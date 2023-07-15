using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Web.ViewModel.Product
{
	public class ProductPreDeleteDetailsViewModel
	{
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		[Display(Name ="Снимка")]
		public string ImageUrl { get; set; } = null!;
	}
}
