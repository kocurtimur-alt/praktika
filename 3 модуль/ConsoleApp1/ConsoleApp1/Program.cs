using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        abstract class Figure
        {
            public abstract double GetArea();
        }

        class Circle : Figure
        {
            public double Radius { get; set; }
            public Circle(double r) => Radius = r;
            public override double GetArea() => Math.PI * Radius * Radius;
        }

        class Rectangle : Figure
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public Rectangle(double w, double h) { Width = w; Height = h; }
            public override double GetArea() => Width * Height;
        }

        class Triangle : Figure
        {
            public double Base { get; set; }
            public double Height { get; set; }
            public Triangle(double b, double h) { Base = b; Height = h; }
            public override double GetArea() => 0.5 * Base * Height;
        }

        // Делегат
        delegate double AreaDelegate();
        static void Main(string[] args)
        {
            Figure circle = new Circle(5);
            Figure rectangle = new Rectangle(4, 6);
            Figure triangle = new Triangle(3, 8);

            AreaDelegate areaCalc = circle.GetArea;
            Console.WriteLine($"Площадь круга: {areaCalc()}");

            areaCalc = rectangle.GetArea;
            Console.WriteLine($"Площадь прямоугольника: {areaCalc()}");

            areaCalc = triangle.GetArea;
            Console.WriteLine($"Площадь треугольника: {areaCalc()}");
        }
    }
}
