namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Enums;
    using ClothesShop.Data.Interfaces;
    using ClothesShop.Data.Miscellaneous;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class Order : ICreatable, IModifiable, IDeletable
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
            OrderProducts = new HashSet<ProductOrder>();
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        [Required]
        public string Id { get; set; }

        public virtual ICollection<ProductOrder> OrderProducts { get; set; }

        public string? ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int ShippingDetailsId { get; set; }

        public virtual ShippingDetails ShippingDetails { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
