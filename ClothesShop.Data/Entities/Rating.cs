namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Enums;
    using ClothesShop.Data.Interfaces;

    using Miscellaneous;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class Rating : ICreatable, IModifiable, IDeletable
    {
        public Rating()
        {
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        [Required]
        public int Id { get; set; }

        public RatingValue? Value { get; set; }

        [Required]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}