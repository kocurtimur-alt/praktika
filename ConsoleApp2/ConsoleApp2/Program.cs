using System;
using System.Linq;

class Program
{
    // ================= Задача 1 =================
    static void Task1()
    {
        Console.Write("Введите размер массива N: ");
        int N = int.Parse(Console.ReadLine());

        double[] arr = new double[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write($"Элемент {i + 1}: ");
            arr[i] = double.Parse(Console.ReadLine());
        }

        double maxAbs = arr.Max(x => Math.Abs(x));
        for (int i = 0; i < N; i++)
            arr[i] /= maxAbs;

        Console.WriteLine("Нормированный массив: " + string.Join(" ", arr));
    }

    // ================= Задача 2 =================
    static void Task2()
    {
        int[] arr = new int[10];
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"Элемент {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Введите число для замены максимального элемента: ");
        int x = int.Parse(Console.ReadLine());

        int maxIndex = 0;
        for (int i = 1; i < arr.Length; i++)
            if (arr[i] > arr[maxIndex]) maxIndex = i;

        arr[maxIndex] = x;
        Console.WriteLine("Массив после замены: " + string.Join(" ", arr));
    }

    // ================= Задача 3 =================
    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++)
            if (n % i == 0) return false;
        return true;
    }

    static void Task3()
    {
        Console.Write("Введите количество простых чисел K: ");
        int K = int.Parse(Console.ReadLine());

        int count = 0, num = 2;
        while (count < K)
        {
            if (IsPrime(num))
            {
                Console.Write($"{num,4}");
                count++;
                if (count % 10 == 0) Console.WriteLine();
            }
            num++;
        }
        Console.WriteLine();
    }

    // ================= Задача 4 =================
    static void Task4()
    {
        Console.Write("Введите размер массива K: ");
        int K = int.Parse(Console.ReadLine());

        Console.Write("Введите A: ");
        int A = int.Parse(Console.ReadLine());

        Console.Write("Введите B: ");
        int B = int.Parse(Console.ReadLine());

        int[] arr = new int[K];
        Random rnd = new Random();

        for (int i = 0; i < K; i++)
            arr[i] = rnd.Next(A, B);

        int minIndex = 0, maxIndex = 0;
        for (int i = 1; i < K; i++)
        {
            if (arr[i] < arr[minIndex]) minIndex = i;
            if (arr[i] > arr[maxIndex]) maxIndex = i;
        }

        if (minIndex > maxIndex)
        {
            int tmp = minIndex;
            minIndex = maxIndex;
            maxIndex = tmp;
        }

        Console.WriteLine("Массив: " + string.Join(" ", arr));
        Console.WriteLine("Элементы между min и max: " +
                          string.Join(" ", arr.Skip(minIndex).Take(maxIndex - minIndex + 1)));
    }

    // ================= Задача 5 =================
    static void Task5()
    {
        Console.Write("Введите размер массива K: ");
        int K = int.Parse(Console.ReadLine());

        Random rnd = new Random();
        string vowels = "аеёиоуыэюя";
        string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        char[] arr = new char[K];
        for (int i = 0; i < K; i++)
            arr[i] = alphabet[rnd.Next(alphabet.Length)];

        char[] consonants = arr.Where(c => !vowels.Contains(c)).ToArray();

        Console.WriteLine("Исходный массив: " + string.Join(" ", arr));
        Console.WriteLine("Согласные: " + string.Join(" ", consonants));
    }

    // ================= Главная программа =================
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задачу (1-5) или 0 для выхода:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 0: return;
                default: Console.WriteLine("Неверный выбор!"); break;
            }
        }
    }
}
