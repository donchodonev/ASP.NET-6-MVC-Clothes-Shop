namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.DataConstants.ClubCardTierConstants;

    public class ClubCardTier
    {
        public ClubCardTier()
        {
            Cards = new HashSet<ClubCard>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [Range(NameMinLength,NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<ClubCard> Cards { get; set; }
    }
}