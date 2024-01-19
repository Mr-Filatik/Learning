using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsoleProject.Entities
{
    internal class OldVersion
    {
        internal static void Run()
        {
            string[] questions;
            string[][] answers;
            int[] rightAnswer;
            int[] currentAnswer;

            questions = InitQuestions();
            answers = InitAnswers();
            rightAnswer = InitRightAnswer();
            currentAnswer = InitCurrentAnswer();

            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Начало тестирования.");
                Console.WriteLine("Введите цифру соответсвующую варианту ответа.");

                for (int i = 0; i < questions.Length; i++)
                {
                    Console.WriteLine(questions[i]);

                    for (int j = 0; j < answers[i].Length; j++)
                    {
                        Console.WriteLine($"{j + 1} - {answers[i][j]}");
                    }

                    int answer = 0;
                    bool isAnswer = false;
                    do
                    {
                        Console.Write("> ");
                        isAnswer = int.TryParse(Console.ReadLine(), out answer);
                        isAnswer = answer >= 1 && answer <= answers[i].Length;
                    }
                    while (!isAnswer);

                    currentAnswer[i] = answer;
                }

                Console.WriteLine("Тестирование закончилось.");

                int number = CheckResult(rightAnswer, currentAnswer);
                Console.WriteLine($"Правильных ответов {number} из {rightAnswer.Length}.");

                Console.WriteLine("Пройти тест заново? Y - да, N - нет.");
                var key = Console.ReadKey();
                if (key.Key != ConsoleKey.Y)
                {
                    isWork = false;
                }
            }
        }

        static string[] InitQuestions()
        {
            string[] output =
            {
                "В каком году были зимние олимпийские игры в Сочи?",
                "В каком году были зимние олимпийские игры в Пекине?"
            };
            return output;
        }

        static string[][] InitAnswers()
        {
            string[][] output = new string[2][];
            output[0] = new string[] { "2001", "2003", "2007", "2014" };
            output[1] = new string[] { "2003", "2003", "2002", "2015", "2000" };
            return output;
        }

        static int[] InitRightAnswer()
        {
            int[] output = { 4, 3 };
            return output;
        }

        static int[] InitCurrentAnswer()
        {
            return new int[2];
        }

        static int CheckResult(int[] rightAnswer, int[] currentAnswer)
        {
            int number = 0;
            for (int i = 0; i < rightAnswer.Length; i++)
            {
                if (rightAnswer[i] == currentAnswer[i])
                {
                    number++;
                }
            }
            return number;
        }
    }
}
