namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;
    using ClothesShop.Data.Miscellaneous;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class Order : ICreatable, IModifiable, IDeletable
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
            Products = new HashSet<Product>();
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        [Required]
        public string Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public string? ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int ShippingDetailsId { get; set; }

        public virtual ShippingDetails ShippingDetails { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
