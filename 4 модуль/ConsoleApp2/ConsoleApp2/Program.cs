using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    interface IProduct
    {
        string Name { get; }
        double GetPrice();
        int GetStock();
    }

    class Food : IProduct
    {
        public string Name { get; }
        public double PricePerKg { get; }
        public double WeightKg { get; }
        public int Stock { get; }

        public Food(string name, double pricePerKg, double weight, int stock)
        {
            Name = name; PricePerKg = pricePerKg; WeightKg = weight; Stock = stock;
        }

        public double GetPrice() => PricePerKg * WeightKg;
        public int GetStock() => Stock;
    }

    class Electronics : IProduct
    {
        public string Name { get; }
        public double Price { get; }
        public int Stock { get; }

        public Electronics(string name, double price, int stock)
        {
            Name = name; Price = price; Stock = stock;
        }

        public double GetPrice() => Price;
        public int GetStock() => Stock;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IProduct[] products = new IProduct[]
            {
                new Food("Яблоки", 2.5, 3, 50),
                new Electronics("Телефон", 499.99, 10)
            };

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name}: цена = {p.GetPrice()} руб., остаток = {p.GetStock()} шт.");
            }
        }
    }
}
