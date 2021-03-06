namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;

    using Miscellaneous;

    using System.ComponentModel.DataAnnotations;

    public class ClubCard : ICreatable, IModifiable, IDeletable
    {
        public ClubCard()
        {
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string ClientId { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        public int ClubCardTierId { get; set; }

        public virtual ClubCardTier Tier { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public bool? ModifiedOn { get; set; }
    }
}
