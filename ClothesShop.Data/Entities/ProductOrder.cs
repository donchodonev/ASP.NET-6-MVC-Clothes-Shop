namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;
    using ClothesShop.Data.Miscellaneous;

    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductOrder : ICreatable
    {
        public ProductOrder()
        {
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        public DateTime CreatedOn { get; set; }

        public string OrderId { get; set; }

        [NotMapped]
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }

        [NotMapped]
        public virtual Product Product { get; set; }
    }
}
