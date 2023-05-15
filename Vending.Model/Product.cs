using System.Collections.Generic;

namespace Vending.Model
{
    public class Product
    {
        public string Name { get; }
        public int Price { get; }

        public static IReadOnlyList<Product> Products = new List<Product>()
        {
            new Product("Американо",12),
            new Product("Латте", 25),
            new Product("Чай",6),
            new Product("Чипсы",23),
            new Product("Батончик",19),
            new Product("Нутелла",670),
        };
        private Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
        
    }
}