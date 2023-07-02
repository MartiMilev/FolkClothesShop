using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkClothesShop.Data.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal OrderTotal { get; set; }


        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int CustomerId { get; set; }

        // Навигационни пропъртита
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
