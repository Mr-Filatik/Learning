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
    /// <summary>
    /// Опросник
    /// </summary>
    internal class Questionnaire
    {
        private IUserManager _userManager; // ссылка на сущность, для управления пользователями
        private IQuestionManager _questionManager; // ссылка на сущность, для управления вопросами

        // переменные для работы с опросником
        private User _currentUser = null; // текущий пользователь
        private bool isWork = true; // работает ли приложение
        private int _rightCount = 0; // количество правильных ответов

        // Конструктор, в котором мы принимаем сущности для работы
        public Questionnaire(IUserManager userManager, IQuestionManager questionManager)
        {
            _userManager = userManager;
            _questionManager = questionManager;
        }

        // основной метод, запускающий опросник
        internal void Run()
        {
            //место загрузки данных (у нас это пока так некрасиво, но представим что они магически появляются с удалённого сервера)
            _userManager.LoadUsers();
            _questionManager.LoadQuestions();

            //запуск работы опросника
            while (isWork)
            {
                if (_currentUser == null)
                {
                    Login();
                }

                DrawMenu();
            }
        }

        /// <summary>
        /// Метод отображения меню
        /// </summary>
        private void DrawMenu()
        {
            Console.WriteLine("Выберите пункт меню:");
            Console.WriteLine("1 - Пройти тест");
            Console.WriteLine("2 - Редактировать вопросы");
            Console.WriteLine("3 - Просмотреть историю");
            Console.WriteLine("0 - Выйти");

            int valueForMenu = GetUserChoice(0, 3);

            // в зависимости от выбора делаем определённые действия
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
        /// Метод, для запуска тестирования (начало, запуск вопросов и окончание).
        /// </summary>
        private void RunTest()
        {
            _rightCount = 0;
            //получаем вопросы
            var quest = _questionManager.GetQuestions();

            Console.WriteLine($"Начало тестирования. Тест содержит {quest.Count} вопросов.");

            //вывод всех вопросов
            for (int i = 0; i < quest.Count; i++)
            {
                RunQuestion(i, quest[i]);
            }

            Console.WriteLine($"Тест завершён. Процент выполнения {((float)_rightCount / quest.Count) * 100} %.");
        }

        /// <summary>
        /// Метод запускающий отображение вопросов и их данных
        /// </summary>
        private void RunQuestion(int index, int id)
        {
            //получение вопроса
            var question = _questionManager.GetQuestion(id);
            //вывод вопроса
            Console.WriteLine($"Вопрос {index + 1}: {question.Text}");

            if (question as SomeRightQuestion != null)
            {
                Console.WriteLine("Выберите несколько вариантов ответа. Для применения ответов введите -1.");
            }
            if (question as OneRightQuestion != null)
            {
                Console.WriteLine("Выберите вариант ответа.");
            }

            //вывод вариантов ответов
            for (int j = 0; j < question.Answers.Count; j++)
            {
                Console.WriteLine($"Ответ ({j + 1}): {question.Answers[j].Text}");
            }

            //Сделать выбор нескольких ответов.
            if (question as SomeRightQuestion != null)
            {
                List<int> answerValue = GetUserChoices(1, question.Answers.Count);

                foreach (int item in answerValue)
                {
                    _questionManager.SetAnswer(question, question.Answers[item - 1].Id);
                }
            }
            if (question as OneRightQuestion != null)
            {
                int answerValue = GetUserChoice(1, question.Answers.Count);

                if (answerValue != -1)
                {
                    _questionManager.SetAnswer(question, question.Answers[answerValue - 1].Id);
                }
            }

            // вывод ответа (правильный или нет)
            if (_questionManager.CalculateAnswers(question))
            {
                _rightCount++;
                Console.WriteLine("Правильно!");
            }
            else
            {
                Console.WriteLine("Неправильно!");
            }
        }

        /// <summary>
        /// Метод считывающий выбор пользователя
        /// </summary>
        private int GetUserChoice(int min, int max)
        {
            //требуем выбор, пока пользователь не выберет из правильного диапазона
            int value = min;
            bool isRange = false;
            do
            {
                Console.Write("Ваш ответ > ");
                isRange = int.TryParse(Console.ReadLine(), out value);
                isRange = value >= min && value <= max;
            }
            while (!isRange);

            return value;
        }

        /// <summary>
        /// Метод считывающий выбор пользователя
        /// </summary>
        private List<int> GetUserChoices(int min, int max)
        {
            //требуем выбор, пока пользователь не выберет из правильного диапазона
            List<int> choices = new List<int>();

            int value = min;
            while (value != -1)
            {
                bool isRange = false;
                do
                {
                    string choiceString = " ";
                    foreach (var item in choices)
                    {
                        choiceString += $"{item} ";
                    }
                    Console.Write($"Ваш ответ{choiceString}> ");
                    isRange = int.TryParse(Console.ReadLine(), out value);
                    isRange = (value == -1) || (value >= min && value <= max);
                    if (value != -1)
                    {
                        if (!choices.Contains(value))
                        {
                            choices.Add(value);
                        }
                        else
                        {
                            choices.Remove(value);
                        }
                    }
                }
                while (!isRange);
            }

            return choices;
        }

        /// <summary>
        /// Метод для авторизации пользователей в приложении
        /// </summary>
        private void Login()
        {
            while (true)
            {
                // ввод логина
                Console.Write("Введите имя пользователя: ");
                string name = Console.ReadLine();

                // ввод пароля
                Console.Write("Введите пароль пользователя: ");
                string password = Console.ReadLine();

                // авторизация пользователя с помощью менеджера пользователей
                // если пользователь вернулся, значит всё прошло отлично
                // если null то такого нет или ошибка
                _currentUser = _userManager.Login(name, password);

                if (_currentUser != null)
                {
                    Console.WriteLine($"Привет {_currentUser.Name}!");
                    break;
                }
                else
                {
                    Console.WriteLine("Пользователь с такими данными не найден! Попробуйте другие данные...");
                }
            }
        }

        /// <summary>
        /// Метод для выхода пользователя из приложения
        /// </summary>
        private void Logout()
        {
            _currentUser = null;
            Console.WriteLine("Производится выход из личного кабинета");
        }
    }
}
