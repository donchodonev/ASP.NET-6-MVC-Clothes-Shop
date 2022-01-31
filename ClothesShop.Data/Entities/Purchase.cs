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
            PurchasesOrders = new HashSet<OrderPurchase>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public int SizeId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [NotMapped]
        public Size Size { get; set; }

        [NotMapped]
        public virtual Product Product { get; set; }

        public int? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        [NotMapped]
        public decimal TotalPrice
        {
            get
            {
                if (Discount != null)
                {
                    return (Price * Count) - ((Price * Count) / 100) * Discount.Percentage;
                }

                return Price * Count;
            }
        }

        [NotMapped]
        public virtual ICollection<OrderPurchase> PurchasesOrders { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
