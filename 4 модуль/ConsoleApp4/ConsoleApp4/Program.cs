using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    interface IBook
    {
        string Title { get; }
        bool IsAvailable();
        void Borrow();
        void ReturnBook();
    }

    class PrintedBook : IBook
    {
        public string Title { get; }
        private bool available;

        public PrintedBook(string title)
        {
            Title = title;
            available = true;
        }

        public bool IsAvailable() => available;

        public void Borrow()
        {
            if (available)
            {
                available = false;
                Console.WriteLine($"Книга '{Title}' выдана.");
            }
            else Console.WriteLine($"Книга '{Title}' недоступна.");
        }

        public void ReturnBook()
        {
            available = true;
            Console.WriteLine($"Книга '{Title}' возвращена.");
        }
    }

    class EBook : IBook
    {
        public string Title { get; }
        public EBook(string title) { Title = title; }

        public bool IsAvailable() => true;
        public void Borrow() => Console.WriteLine($"Электронная книга '{Title}' открыта.");
        public void ReturnBook() => Console.WriteLine($"Электронная книга '{Title}' закрыта.");
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IBook book1 = new PrintedBook("Преступление и наказание");
            IBook book2 = new EBook("C# для начинающих");

            book1.Borrow();
            book1.Borrow();
            book1.ReturnBook();

            book2.Borrow();
            book2.ReturnBook();
        }
    }
}
