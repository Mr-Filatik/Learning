using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mail;
using StudyLibraryProject.Abstract;
using StudyConsoleProject.Managers;
using StudyLibraryProject.Managers;
using StudyLibraryProject;

namespace StudyConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // имимтируем работу внедрения зависимости (она выполняется за нас автоматически)
            Questionnaire questionnaire = new Questionnaire(new UserManager(), new QuestionManager(), new ConsoleIOManager());

            // запуск работы опросника
            questionnaire.Run();

            // запуск старого опросника
            //OldVersion.Run();
        }
    }
}