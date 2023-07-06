using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Data.Entity
{
	public class Admin
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string UserId { get; set; } = null!;
		public IdentityUser User { get; set; } = null!;
	}
}
