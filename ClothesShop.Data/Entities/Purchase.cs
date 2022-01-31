namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;
    using ClothesShop.Data.Miscellaneous;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Purchase : ICreatable
    {
        public Purchase()
        {
            CreatedOn = DateTimeProvider.CurrentTime;
            PurchasesOrders = new HashSet<PurchaseOrder>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public int? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public int OrderId { get; set; }

        [NotMapped]
        public Order Order { get; set; }

        [NotMapped]
        public decimal TotalPrice => Price - (Price / 100) * Discount.Percentage;

        public ICollection<PurchaseOrder> PurchasesOrders { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
