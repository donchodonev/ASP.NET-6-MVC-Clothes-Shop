namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Enums;

    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        [Required]
        public int Id { get; set; }

        public RatingValue? Value { get; set; }

        public Client Client { get; set; }
    }
}