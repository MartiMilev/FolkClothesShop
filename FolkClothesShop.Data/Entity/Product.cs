using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Data.Entity
{
    public class Product
    {
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; } = null!;
		[Required]
		public string Description { get; set; } = null!;
		[Required]
		public string ImageUrl { get; set; } = null!;
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int CategoryId { get; set; }
		public Category Category { get; set; } = null!;
		public int AdminId { get; set; }
		public Admin Admin { get; set; } = null!;
	}
}
