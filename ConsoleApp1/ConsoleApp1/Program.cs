using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            long factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine($"Факториал числа {n} = {factorial}");

            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine($"Сумма = {a + b}");

            Console.Write("Введите строку: ");
            string input = Console.ReadLine();
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);

            Console.WriteLine("Обратная строка: " + new string(arr));

            Random rand = new Random();
            int[] array = new int[15];

            Console.WriteLine("Массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-10, 20); // числа от -10 до 19
                Console.Write(array[i] + " ");
            }

            int sum = 0, count = 0;
            foreach (int num in array)
            {
                if (num > 0)
                {
                    sum += num;
                    count++;
                }
            }

            Console.WriteLine();
            if (count > 0)
                Console.WriteLine($"Среднее положительных чисел = {(double)sum / count}");
            else
                Console.WriteLine("В массиве нет положительных чисел.");

            Console.Write("Введите число: ");
            int k = int.Parse(Console.ReadLine());
            bool isPrime = true;

            if (k <= 1)
                isPrime = false;
            else
            {
                for (int i = 2; i <= Math.Sqrt(k); i++)
                {
                    if (k % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            Console.WriteLine(isPrime ? "Число простое" : "Число не является простым");
        }
    }
}
