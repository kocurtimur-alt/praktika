using System;
using System.Linq;

namespace Tasks
{
    // ---------------- Задача 1 ----------------
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double AverageGrade { get; set; }

        public Student(string firstName, string lastName, int age, double avg)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            AverageGrade = avg;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{FirstName} {LastName}, Возраст: {Age}, Ср.балл: {AverageGrade}");
        }
    }

    // ---------------- Задача 2 ----------------
    struct Train
    {
        public string Destination;
        public int TrainNumber;
        public TimeSpan DepartureTime;

        public Train(string dest, int num, TimeSpan time)
        {
            Destination = dest;
            TrainNumber = num;
            DepartureTime = time;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Поезд {TrainNumber}, Пункт назначения: {Destination}, Время: {DepartureTime}");
        }
    }

    // ---------------- Задача 3 ----------------
    abstract class Shape
    {
        public abstract double Area();
        public abstract double Perimeter();
    }

    class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double r) { Radius = r; }

        public override double Area() => Math.PI * Radius * Radius;
        public override double Perimeter() => 2 * Math.PI * Radius;
    }

    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double w, double h) { Width = w; Height = h; }

        public override double Area() => Width * Height;
        public override double Perimeter() => 2 * (Width + Height);
    }

    class Triangle : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public Triangle(double a, double b, double c) { A = a; B = b; C = c; }

        public override double Area()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public override double Perimeter() => A + B + C;
    }

    // ---------------- Main ----------------
    class Program
    {
        static void Main()
        {
            // ===== Задача 1 =====
            Console.WriteLine("=== Задача 1: Студенты ===");
            Student s1 = new Student("Тимур", "Коцур", 17, 7.9);
            Student s2 = new Student("Мария", "Потеева", 17, 8.2);
            Student s3 = new Student("Егор", "Кухаренко", 17, 6.8);

            s1.PrintInfo();
            s2.PrintInfo();
            s3.PrintInfo();

            // ===== Задача 2 =====
            Console.WriteLine("\n=== Задача 2: Поезда ===");
            Train[] trains = new Train[5];
            trains[0] = new Train("Москва", 103, new TimeSpan(9, 30, 0));
            trains[1] = new Train("Сочи", 205, new TimeSpan(12, 15, 0));
            trains[2] = new Train("Казань", 101, new TimeSpan(6, 50, 0));
            trains[3] = new Train("Сочи", 150, new TimeSpan(10, 00, 0));
            trains[4] = new Train("Москва", 120, new TimeSpan(8, 15, 0));

            // сортировка по номеру
            Console.WriteLine("\nСортировка по номерам поездов:");
            var byNumber = trains.OrderBy(t => t.TrainNumber).ToArray();
            foreach (var t in byNumber) t.PrintInfo();

            // поиск по номеру
            Console.Write("\nВведите номер поезда для поиска: ");
            int searchNum = int.Parse(Console.ReadLine());
            var found = trains.FirstOrDefault(t => t.TrainNumber == searchNum);
            if (found.TrainNumber != 0) found.PrintInfo();
            else Console.WriteLine("Такого поезда нет");

            // сортировка по пункту назначения и времени
            Console.WriteLine("\nСортировка по пункту назначения и времени:");
            var byDest = trains.OrderBy(t => t.Destination)
                               .ThenBy(t => t.DepartureTime)
                               .ToArray();
            foreach (var t in byDest) t.PrintInfo();

            // ===== Задача 3 =====
            Console.WriteLine("\n=== Задача 3: Фигуры ===");
            Shape c = new Circle(5);
            Shape r = new Rectangle(4, 6);
            Shape tr = new Triangle(3, 4, 5);

            Console.WriteLine($"Круг: Площадь={c.Area():F2}, Периметр={c.Perimeter():F2}");
            Console.WriteLine($"Прямоугольник: Площадь={r.Area()}, Периметр={r.Perimeter()}");
            Console.WriteLine($"Треугольник: Площадь={tr.Area()}, Периметр={tr.Perimeter()}");
        }
    }
}
