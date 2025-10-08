using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Notification
    {
        public event Action<string> OnMessageSent;
        public event Action<string> OnCallSent;
        public event Action<string> OnEmailSent;

        public void SendMessage(string msg) => OnMessageSent?.Invoke(msg);
        public void MakeCall(string contact) => OnCallSent?.Invoke(contact);
        public void SendEmail(string email) => OnEmailSent?.Invoke(email);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Notification n = new Notification();

            n.OnMessageSent += msg => Console.WriteLine($"📱 Сообщение: {msg}");
            n.OnCallSent += c => Console.WriteLine($"📞 Звонок: {c}");
            n.OnEmailSent += e => Console.WriteLine($"📧 Email: {e}");

            n.SendMessage("Привет!");
            n.MakeCall("Мама");
            n.SendEmail("example@mail.com");
        }
    }
}
