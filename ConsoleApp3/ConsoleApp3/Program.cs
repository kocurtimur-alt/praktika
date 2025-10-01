using System;
using System.Linq;

class Program
{
    // ================= Задача 1 =================
    // НОД (Алгоритм Евклида)
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static void Task1()
    {
        Console.Write("Введите числитель (неотрицательное число): ");
        int numerator = int.Parse(Console.ReadLine());
        Console.Write("Введите знаменатель (положительное число): ");
        int denominator = int.Parse(Console.ReadLine());

        if (denominator <= 0)
        {
            Console.WriteLine("Знаменатель должен быть положительным!");
            return;
        }

        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;

        Console.WriteLine($"Сокращённая дробь: {numerator}/{denominator}");
    }

    // ================= Задача 2 =================
    static void Task2()
    {
        Console.Write("Введите число-ограничение суммы: ");
        int limit = int.Parse(Console.ReadLine());

        Random rnd = new Random();
        int sum = 0;
        var list = new System.Collections.Generic.List<int>();

        while (true)
        {
            int val = rnd.Next(1, 10); // [1;9]
            if (sum + val > limit) break;
            list.Add(val);
            sum += val;
        }

        Console.WriteLine("Сформированный массив: " + string.Join(" ", list));
        Console.WriteLine("Сумма элементов = " + sum);
    }

    // ================= Задача 3 =================
    static void Task3()
    {
        Console.Write("Введите размер матрицы N: ");
        int N = int.Parse(Console.ReadLine());

        Random rnd = new Random();
        int[,] matrix = new int[N, N];

        // заполнение матрицы
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                matrix[i, j] = rnd.Next(-50, 51);

        Console.WriteLine("\nИсходная матрица:");
        PrintMatrix(matrix);

        // вычисляем суммы строк
        var rows = new (int[] row, int sum)[N];
        for (int i = 0; i < N; i++)
        {
            int[] row = new int[N];
            for (int j = 0; j < N; j++)
                row[j] = matrix[i, j];
            rows[i] = (row, row.Sum());
        }

        // сортировка по сумме
        rows = rows.OrderBy(r => r.sum).ToArray();

        // формируем отсортированную матрицу
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                matrix[i, j] = rows[i].row[j];

        Console.WriteLine("\nМатрица после сортировки строк по суммам:");
        PrintMatrix(matrix);
    }

    static void PrintMatrix(int[,] matrix)
    {
        int N = matrix.GetLength(0);
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write($"{matrix[i, j],5}");
            Console.WriteLine();
        }
    }

    // ================= Главная программа =================
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задачу (1-3) или 0 для выхода:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 0: return;
                default: Console.WriteLine("Неверный выбор!"); break;
            }
        }
    }
}
