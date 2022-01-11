namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Enums;
    using ClothesShop.Data.Interfaces;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class Rating : ICreatable, IModifiable, IDeletable
    {
        [Required]
        public int Id { get; set; }

        public RatingValue? Value { get; set; }

        public Client Client { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}