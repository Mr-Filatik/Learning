using StudyConsoleProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsoleProject.Abstract
{
    internal interface IQuestionManager
    {
        void AddQuestion();
        void RemoveQuestion();
        void EditQuestion();

        bool LoadQuestions();
        List<int> GetQuestions();
        Question GetQuestion(int id);
        bool CalculateAnswers(Question question);
        void SetAnswer(Question question, int answerId);
    }
}
