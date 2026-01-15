using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Колекцiя даних
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Quantity = 15, Price = 1200 },
                new Product { Id = 2, Name = "Mouse", Category = "Electronics", Quantity = 40, Price = 600 },
                new Product { Id = 3, Name = "Monitor", Category = "Electronics", Quantity = 10, Price = 7000 },
                new Product { Id = 4, Name = "Chair", Category = "Furniture", Quantity = 5, Price = 3500 },
                new Product { Id = 5, Name = "Desk", Category = "Furniture", Quantity = 3, Price = 9000 }
            };

            // ===== ВИБIРКА ДАНИХ (мiн. 3) =====
            var electronics = products.Where(p => p.Category == "Electronics");
            var productNames = products.Select(p => p.Name);
            var cheapProduct = products.FirstOrDefault(p => p.Price < 1000);

            // ===== ЗМIНА ПОРЯДКУ (мiн. 3) =====
            var sortedByPrice = products.OrderBy(p => p.Price);
            var sortedByQuantityDesc = products.OrderByDescending(p => p.Quantity);
            var sortedComplex = products
                .OrderBy(p => p.Category)
                .ThenBy(p => p.Price);

            // ===== ДОДАТКОВА ВИБIРКА (мін. 2) =====
            var top3Expensive = products
                .OrderByDescending(p => p.Price)
                .Take(3);

            bool hasLowStock = products.Any(p => p.Quantity < 5);

            // ===== УПРАВЛIННЯ ЗАПИТАМИ (мiн. 1) =====
            var groupedByCategory = products.GroupBy(p => p.Category);

            // ===== ВИВIД =====
            Console.WriteLine("Товари згрупованi за категорiями:\n");

            foreach (var group in groupedByCategory)
            {
                Console.WriteLine($"Категорiя: {group.Key}");
                foreach (var product in group)
                {
                    Console.WriteLine(
                        $"  {product.Name} | К-сть: {product.Quantity} | Цiна: {product.Price} грн");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Топ 3 найдорожчi товари:");
            foreach (var product in top3Expensive)
            {
                Console.WriteLine($"{product.Name} - {product.Price} грн");
            }

            Console.WriteLine($"\nЄ товар з малою кiлькiстю (<5): {hasLowStock}");

            Console.ReadKey();
        }
    }

    // Модель даних (в тому ж файлi)
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}