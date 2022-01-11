namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Enums;
    using ClothesShop.Data.ValidationAttributes;

    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Product;
    using static DataConstants.Client;
    using System.ComponentModel.DataAnnotations.Schema;

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

        public AgeGroup? AgeGroup { get; set; }

        public GenderGroup? Gender{ get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public int ShippingAddressId { get; set; }

        public virtual ShippingAddress ShippingAddress { get; set; }
    }
}
