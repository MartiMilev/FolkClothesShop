using System.ComponentModel.DataAnnotations;

namespace FolkClothesShop.Data.Entity
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;

        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;

        public int Quantity { get; set; }
    }
}