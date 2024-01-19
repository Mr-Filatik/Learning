using StudyConsoleProject.Abstract;
using StudyConsoleProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudyConsoleProject
{
    internal class Questionnaire
    {
        private IUserManager _userManager;
        private IQuestionManager _questionManager;

        private User _currentUser = null;
        private bool isWork = true;
        private int _rightCount = 0;

        public Questionnaire(IUserManager userManager, IQuestionManager questionManager)
        {
            _userManager = userManager;
            _questionManager = questionManager;
        }

        internal void Run()
        {
            _userManager.LoadUsers();
            _questionManager.LoadQuestions();

            while (isWork)
            {
                Login();

                if (_currentUser != null)
                {
                    Console.WriteLine($"Привет {_currentUser.Name}!");

                    DrawMenu();
                }
                else
                {
                    Console.WriteLine("Пользователь с такими данными не найден! Попробуйте другие данные...");
                }
            }
        }

        private void DrawMenu()
        {
            Console.WriteLine("Выберите пункт меню:");
            Console.WriteLine("1 - Пройти тест");
            Console.WriteLine("2 - Редактировать вопросы");
            Console.WriteLine("3 - Просмотреть историю");
            Console.WriteLine("0 - Выйти");

            int valueForMenu = GetUserChoice(0, 3);

            if (valueForMenu == 0)
            {
                Logout();
            }
            if (valueForMenu == 1)
            {
                RunTest();
            }
            if (valueForMenu == 2)
            {

            }
            if (valueForMenu == 3)
            {

            }
        }

        /// <summary>
        /// Метод, для отображения тестирования (начало, запуск вопросов и окончание).
        /// </summary>
        private void RunTest()
        {
            _rightCount = 0;
            var quest = _questionManager.GetQuestions();

            Console.WriteLine($"Начало тестирования. Тест содержит {quest.Count} вопросов.");

            for (int i = 0; i < quest.Count; i++)
            {
                RunQuestion(i, quest[i]);
            }

            Console.WriteLine($"Тест завершён. Процент выполнения {((float)_rightCount / quest.Count) * 100} %.");
        }

        private void RunQuestion(int index, int id)
        {
            var q = _questionManager.GetQuestion(id);
            Console.WriteLine($"Вопрос {index + 1}: {q.Text}");

            for (int j = 0; j < q.Answers.Count; j++)
            {
                Console.WriteLine($"Ответ ({j + 1}): {q.Answers[j].Text}");
            }

            //Сделать выбор нескольких ответов.
            int value = GetUserChoice(1, q.Answers.Count);

            if (_questionManager.CalculateAnswers(q, value - 1))
            {
                _rightCount++;
                Console.WriteLine("Правильно!");
            }
            else
            {
                Console.WriteLine("Неправильно!");
            }
        }

        private int GetUserChoice(int min, int max)
        {
            int value = min;
            bool isRange = false;
            do
            {
                Console.Write("> ");
                isRange = int.TryParse(Console.ReadLine(), out value);
                isRange = value >= min && value <= max;
            }
            while (!isRange);

            return value;
        }

        private void Login()
        {
            Console.Write("Введите имя пользователя: ");
            string name = Console.ReadLine();

            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();

            _currentUser = _userManager.Login(name, password);
        }

        private void Logout()
        {
            _currentUser = null;
            Console.WriteLine("Производится выход из личного кабинета");
        }
    }
}
