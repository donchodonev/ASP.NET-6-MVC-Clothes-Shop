namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;
    using ClothesShop.Data.Miscellaneous;

    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderPurchase : ICreatable
    {
        public OrderPurchase()
        {
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        public DateTime CreatedOn { get; set; }

        public string OrderId { get; set; }

        [NotMapped]
        public virtual Order Order { get; set; }

        public int PurchaseId { get; set; }

        [NotMapped]
        public virtual Purchase Purchase { get; set; }
    }
}
