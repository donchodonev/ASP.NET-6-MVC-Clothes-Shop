namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.ValidationAttributes;

    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataConstants.ClientConstants;
    using static DataConstants.ProductConstants;

    public class Client : IdentityUser
    {
        public Client()
        {
            Ratings = new HashSet<Rating>();
        }


        [ValidPrice(Zero,DecimalMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal MoneySpent { get; set; }

        public int? CardId { get; set; }

        public virtual ClubCard Card { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        [Range(MinAge,MaxAge)]
        public int? Age { get; set; }

        public int? AgeGroupId { get; set; }

        public virtual AgeGroup AgeGroup { get; set; }

        public int? GenderId { get; set; }

        public virtual GenderGroup Gender{ get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public int ShippingAddressId { get; set; }

        public virtual ShippingAddress ShippingAddress { get; set; }
    }
}
