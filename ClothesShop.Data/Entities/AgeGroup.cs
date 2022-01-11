﻿namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using ClothesShop.Data.Enums;

    public class AgeGroup
    {
        [Required]
        public int Id { get; set; }

        public AgeGroupName Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
