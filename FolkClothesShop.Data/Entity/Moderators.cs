
namespace FolkClothesShop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Moderator ;
    public class Moderators
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [MaxLength(MaxLenghtModeratorName)]
        [MinLength(MinLenghtModeratorName)]
        public string Name { get; set; } = null!;


    }
}