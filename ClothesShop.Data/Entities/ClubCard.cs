namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Enums;

    using System.ComponentModel.DataAnnotations;

    public class ClubCard
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ClientId { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        [Required]
        public ClubCardTier Tier { get; set; }
    }
}
