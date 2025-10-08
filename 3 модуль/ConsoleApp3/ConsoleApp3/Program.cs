using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    delegate void TaskAction(string task);

    class Program
    {
        static void LogTask(string task) => Console.WriteLine($"📝 Задача записана в журнал: {task}");
        static void NotifyTask(string task) => Console.WriteLine($"🔔 Уведомление: {task}");

        static void Main()
        {
            List<(string, TaskAction)> tasks = new List<(string, TaskAction)>();

            tasks.Add(("Позвонить врачу", NotifyTask));
            tasks.Add(("Купить продукты", LogTask));

            foreach (var (task, action) in tasks)
            {
                Console.WriteLine($"Выполняем задачу: {task}");
                action(task);
            }
        }
    }
}
