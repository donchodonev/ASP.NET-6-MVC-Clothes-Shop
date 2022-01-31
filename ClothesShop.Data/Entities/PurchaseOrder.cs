namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;
    using ClothesShop.Data.Miscellaneous;

    using System.ComponentModel.DataAnnotations.Schema;

    public class PurchaseOrder : ICreatable
    {
        public PurchaseOrder()
        {
            CreatedOn = DateTimeProvider.CurrentTime;
            PurchasesOrders = new HashSet<PurchaseOrder>();
        }

        public DateTime CreatedOn { get; set; }

        public string OrderId { get; set; }

        [NotMapped]
        public virtual Order Order { get; set; }

        public int PurchaseId { get; set; }

        [NotMapped]
        public virtual Purchase Purchase { get; set; }

        [NotMapped]
        public ICollection<PurchaseOrder> PurchasesOrders { get; set; }
    }
}
