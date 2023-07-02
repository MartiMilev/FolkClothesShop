using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FolkClothesShop.Data.Entity
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        // Навигационни пропъртита
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; } = null!;

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;
    }
}