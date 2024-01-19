using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mail;
using StudyConsoleProject.Abstract;
using StudyConsoleProject.Entities;
using StudyConsoleProject.Managers;

namespace StudyConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Questionnaire questionnaire = new Questionnaire(new UserManager(), new QuestionManager());
            questionnaire.Run();

            //OldVersion.Run();
        }
    }
}