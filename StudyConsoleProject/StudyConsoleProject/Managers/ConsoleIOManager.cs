using StudyLibraryProject.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsoleProject.Managers
{
    internal class ConsoleIOManager : IIOManager
    {
        public void ShowMessage(string text)
        {
            Console.WriteLine();
            Console.WriteLine(text);
        }

        public void ShowError(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowLogin(Action<string, string> action)
        {
            // ввод логина
            Console.WriteLine();
            Console.Write("Введите имя пользователя: ");
            string name = Console.ReadLine();

            // ввод пароля
            Console.WriteLine();
            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();

            action(name, password);
        }

        public void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите пункт меню:");
            Console.WriteLine("1 - Пройти тест");
            Console.WriteLine("2 - Редактировать вопросы");
            Console.WriteLine("3 - Просмотреть историю");
            Console.WriteLine("0 - Выйти");
        }

        public string? GetData()
        {
            return Console.ReadLine();
        }
    }
}
