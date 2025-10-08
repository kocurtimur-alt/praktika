using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    interface IStudent
    {
        string Name { get; }
        double GetAverageGrade();
        string GetCourseInfo();
    }

    class BachelorStudent : IStudent
    {
        public string Name { get; }
        public List<int> Grades { get; }

        public BachelorStudent(string name, List<int> grades)
        {
            Name = name; Grades = grades;
        }

        public double GetAverageGrade() => Grades.Average();
        public string GetCourseInfo() => "Бакалавр (4 года)";
    }

    class MasterStudent : IStudent
    {
        public string Name { get; }
        public List<int> Grades { get; }

        public MasterStudent(string name, List<int> grades)
        {
            Name = name; Grades = grades;
        }

        public double GetAverageGrade() => Grades.Average();
        public string GetCourseInfo() => "Магистр (2 года)";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<IStudent> students = new List<IStudent>
            {
                new BachelorStudent("Иван", new List<int>{5, 4, 4, 5}),
                new MasterStudent("Анна", new List<int>{5, 5, 5, 4})
            };

            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name}: {s.GetCourseInfo()}, ср. балл = {s.GetAverageGrade():F2}");
            }
        }
    }
}
