namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ClubCardTier
    {
        public ClubCardTier()
        {
            Cards = new HashSet<ClubCard>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ClubCard> Cards { get; set; }
    }
}