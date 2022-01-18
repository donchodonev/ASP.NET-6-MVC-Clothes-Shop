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
            Products = new HashSet<Product>();
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        [Required]
        public int Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int ShippingAddressId { get; set; }

        public virtual ShippingAddress ShippingAddress { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
