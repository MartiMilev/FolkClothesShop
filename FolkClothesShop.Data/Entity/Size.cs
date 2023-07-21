using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Data.Entity
{
	public class Size
	{
		[Key]
		public int Id { get; set; }
		[Comment("Size name of product")]
		public string Name { get; set; } = null!;
		public IEnumerable<Product> Products { get; set; } = new List<Product>();

	}
}
