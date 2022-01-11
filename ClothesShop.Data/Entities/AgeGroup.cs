﻿namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class AgeGroup
    {
        public AgeGroup()
        {
            Clients = new HashSet<Client>();
            Products = new HashSet<Product>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
