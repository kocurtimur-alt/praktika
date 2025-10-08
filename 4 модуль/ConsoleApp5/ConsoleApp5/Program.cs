using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    interface IDrawing
    {
        void DrawLine(int x1, int y1, int x2, int y2);
        void DrawCircle(int x, int y, int radius);
        void DrawRectangle(int x, int y, int width, int height);
    }

    class Canvas : IDrawing
    {
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            Console.WriteLine($"Рисуется линия: ({x1},{y1}) -> ({x2},{y2})");
        }

        public void DrawCircle(int x, int y, int radius)
        {
            Console.WriteLine($"Рисуется круг: центр ({x},{y}), радиус {radius}");
        }

        public void DrawRectangle(int x, int y, int width, int height)
        {
            Console.WriteLine($"Рисуется прямоугольник: левый верхний угол ({x},{y}), {width}x{height}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IDrawing canvas = new Canvas();

            canvas.DrawLine(0, 0, 100, 100);
            canvas.DrawCircle(50, 50, 20);
            canvas.DrawRectangle(10, 10, 40, 30);
        }
    }
}
