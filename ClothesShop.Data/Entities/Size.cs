namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;
    using ClothesShop.Data.Miscellaneous;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.SizeConstants;

    public class Size : ICreatable, IModifiable, IDeletable
    {
        public Size()
        {
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [Range(SizeNameMinLength, SizeNameMaxLength)]
        public string Value { get; set; }

        [Required]
        public int Count { get; set; }

        public bool? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
