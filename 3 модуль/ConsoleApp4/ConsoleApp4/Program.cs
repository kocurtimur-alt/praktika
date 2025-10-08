using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    delegate bool Filter(string item);
    internal class Program
    {
        static bool FilterByKeyword(string item) => item.Contains("важно");
        static bool FilterByLength(string item) => item.Length > 10;

        static void Main()
        {
            List<string> data = new List<string> { "важное сообщение", "привет", "длинный текст", "короткий" };

            Filter filter = FilterByKeyword;

            var result = data.Where(x => filter(x));

            Console.WriteLine("Отфильтрованные данные:");
            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
}
