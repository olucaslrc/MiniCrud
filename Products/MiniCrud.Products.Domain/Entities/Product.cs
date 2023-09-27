using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCrud.Products.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}