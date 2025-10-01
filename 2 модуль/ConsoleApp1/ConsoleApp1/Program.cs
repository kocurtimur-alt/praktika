using System;
using System.Collections.Generic;

namespace OOPTasks
{
    // ---------------- Задача 1 ----------------
    class Person
    {
        private string name;
        private int age;
        private string address;

        public void SetName(string n) => name = n;
        public string GetName() => name;

        public void SetAge(int a) => age = a;
        public int GetAge() => age;

        public void SetAddress(string addr) => address = addr;
        public string GetAddress() => address;

        public void PrintInfo()
        {
            Console.WriteLine($"Имя: {name}, Возраст: {age}, Адрес: {address}");
        }
    }

    // ---------------- Задача 2 ----------------
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

    // ---------------- Задача 3 ----------------
    class Author
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }

        public Author(string name, int birthYear)
        {
            Name = name;
            BirthYear = birthYear;
        }
    }

    class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Author Author { get; set; }

        public Book(string title, int year, Author author)
        {
            Title = title;
            Year = year;
            Author = author;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Книга: {Title}, {Year}, Автор: {Author.Name} ({Author.BirthYear})");
        }
    }

    // ---------------- Задача 4 ----------------
    interface IDrawable
    {
        void Draw();
    }

    class DrawableCircle : IDrawable
    {
        public void Draw() => Console.WriteLine("Рисую круг");
    }

    class DrawableRectangle : IDrawable
    {
        public void Draw() => Console.WriteLine("Рисую прямоугольник");
    }

    class Triangle : IDrawable
    {
        public void Draw() => Console.WriteLine("Рисую треугольник");
    }

    // ---------------- Задача 5 ----------------
    class TemperatureChangedEventArgs : EventArgs
    {
        public double NewTemperature { get; }
        public TemperatureChangedEventArgs(double temp) { NewTemperature = temp; }
    }

    class TemperatureSensor
    {
        private double temperature;
        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

        public double Temperature
        {
            get => temperature;
            set
            {
                if (temperature != value)
                {
                    temperature = value;
                    OnTemperatureChanged(new TemperatureChangedEventArgs(value));
                }
            }
        }

        protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            TemperatureChanged?.Invoke(this, e);
        }
    }

    class Thermostat
    {
        public void Subscribe(TemperatureSensor sensor)
        {
            sensor.TemperatureChanged += OnTemperatureChanged;
        }

        private void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            if (e.NewTemperature < 18)
                Console.WriteLine($"Температура {e.NewTemperature}°C → Включаем отопление");
            else if (e.NewTemperature > 25)
                Console.WriteLine($"Температура {e.NewTemperature}°C → Выключаем отопление");
            else
                Console.WriteLine($"Температура {e.NewTemperature}°C → Всё нормально");
        }
    }

    // ---------------- Main ----------------
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Задача 1: Класс Person ===");
            Person p1 = new Person();
            p1.SetName("Иван");
            p1.SetAge(30);
            p1.SetAddress("Москва");
            p1.PrintInfo();

            Console.WriteLine("\n=== Задача 2: Наследование (Shape) ===");
            Shape c = new Circle(5);
            Shape r = new Rectangle(4, 6);
            Console.WriteLine($"Круг: Площадь={c.Area():F2}, Периметр={c.Perimeter():F2}");
            Console.WriteLine($"Прямоугольник: Площадь={r.Area()}, Периметр={r.Perimeter()}");

            Console.WriteLine("\n=== Задача 3: Композиция (Author/Book) ===");
            Author a1 = new Author("Пушкин", 1799);
            Author a2 = new Author("Толстой", 1828);
            Book b1 = new Book("Евгений Онегин", 1833, a1);
            Book b2 = new Book("Война и мир", 1869, a2);
            b1.PrintInfo();
            b2.PrintInfo();

            Console.WriteLine("\n=== Задача 4: Интерфейсы (IDrawable) ===");
            IDrawable[] figures = { new DrawableCircle(), new DrawableRectangle(), new Triangle() };
            foreach (var f in figures) f.Draw();

            Console.WriteLine("\n=== Задача 5: События (TemperatureSensor) ===");
            TemperatureSensor sensor = new TemperatureSensor();
            Thermostat thermostat = new Thermostat();
            thermostat.Subscribe(sensor);

            sensor.Temperature = 15; // отопление включится
            sensor.Temperature = 22; // нормально
            sensor.Temperature = 28; // отопление выключится
        }
    }
}
