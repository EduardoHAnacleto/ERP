using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public Brand Brand { get; private set; }
        public Category Category { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

        public Product() { }
        public Product(string name, string description, decimal price, int stockQuantity, Brand brand, Category category)
        {
            Name = name; Description = description; Price = price; StockQuantity = stockQuantity; Brand = brand; Category = category;
        }

        public void AddStock(int quantity) => StockQuantity += quantity;
        public void RemoveStock(int quantity) => StockQuantity -= quantity;
    }
}
