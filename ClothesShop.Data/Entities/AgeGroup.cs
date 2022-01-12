﻿namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.DataConstants.AgeGroupConstants;

    public class AgeGroup
    {
        public AgeGroup()
        {
            Clients = new HashSet<Client>();
            Products = new HashSet<Product>();
        }

        [Required]
        public int Id { get; set; }

        [Range(NameMinLength,NameMaxLength)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
