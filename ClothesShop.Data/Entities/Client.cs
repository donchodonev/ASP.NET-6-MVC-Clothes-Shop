namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Enums;
    using ClothesShop.Data.ValidationAttributes;

    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Product;
    using static DataConstants.Client;

    public class Client : IdentityUser
    {
        [ValidPrice(Zero,DecimalMaxValue)]
        public decimal MoneySpent { get; set; }

        public int CardId { get; set; }

        public virtual ClubCard? Card { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        [Range(MinAge,MaxAge)]
        public int? Age { get; set; }

        public AgeGroup? AgeGroup { get; set; }

        public GenderGroup? Gender{ get; set; }
    }
}
