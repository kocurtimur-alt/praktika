using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        delegate void SortDelegate(List<int> numbers);
        static void BubbleSort(List<int> nums)
        {
            for (int i = 0; i < nums.Count - 1; i++)
                for (int j = 0; j < nums.Count - i - 1; j++)
                    if (nums[j] > nums[j + 1])
                        (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
        }

        static void QuickSort(List<int> nums)
        {
            nums.Sort(); // используем встроенный быстрый алгоритм
        }

        static void Main()
        {
            List<int> numbers = new List<int> { 5, 2, 8, 1, 9 };

            SortDelegate sorter = BubbleSort;
            sorter(numbers);
            Console.WriteLine("Пузырьковая сортировка: " + string.Join(", ", numbers));

            numbers = new List<int> { 5, 2, 8, 1, 9 };
            sorter = QuickSort;
            sorter(numbers);
            Console.WriteLine("Быстрая сортировка: " + string.Join(", ", numbers));
        }
    }
}
