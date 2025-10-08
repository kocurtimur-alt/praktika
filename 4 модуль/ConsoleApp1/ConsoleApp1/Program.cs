using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IFigure
    {
        double GetArea();
        double GetPerimeter();
    }

    class Circle : IFigure
    {
        public double Radius { get; set; }
        public Circle(double r) { Radius = r; }

        public double GetArea() => Math.PI * Radius * Radius;
        public double GetPerimeter() => 2 * Math.PI * Radius;
    }

    class Rectangle : IFigure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double w, double h) { Width = w; Height = h; }

        public double GetArea() => Width * Height;
        public double GetPerimeter() => 2 * (Width + Height);
    }

    class Triangle : IFigure
    {
        public double A, B, C;
        public Triangle(double a, double b, double c) { A = a; B = b; C = c; }

        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public double GetPerimeter() => A + B + C;
    }
    internal class Program
    { 
        static void Main(string[] args)
        {
            IFigure[] figures = new IFigure[]
            {
                new Circle(5),
                new Rectangle(4, 7),
                new Triangle(3, 4, 5)
            };

            foreach (var f in figures)
            {
                Console.WriteLine($"Фигура: {f.GetType().Name}");
                Console.WriteLine($"Площадь: {f.GetArea():F2}, Периметр: {f.GetPerimeter():F2}\n");
            }
        }
    }
}
