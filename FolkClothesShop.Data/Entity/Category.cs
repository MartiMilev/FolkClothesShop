using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Data.Entity
{
    public class Category
    {
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(10, MinimumLength = 5)]
		public string Name { get; set; } = null!;
		public IEnumerable<Product> Products { get; set; } = new List<Product>();
	}

}
