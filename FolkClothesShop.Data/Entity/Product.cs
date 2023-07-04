﻿using System;
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
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(200,MinimumLength =10)]
        public string Description { get; set; } = null!;
        [Required]
        public string Image { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;
        [Required]
        public int AdmintId { get; set; }
        public Admin Admin { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
