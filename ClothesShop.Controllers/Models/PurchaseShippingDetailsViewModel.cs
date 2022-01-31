namespace ClothesShop.Controllers.Models
{
    public class PurchaseShippingDetailsViewModel
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string RecipientFirstName { get; set; }

        public string RecipientLastName { get; set; }

        public string RecipientEmailAddress { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}