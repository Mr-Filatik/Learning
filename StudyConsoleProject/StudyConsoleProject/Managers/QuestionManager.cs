using StudyConsoleProject.Abstract;
using StudyConsoleProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsoleProject.Managers
{
    /// <summary>
    /// сущность для взаимодействия с вопросами
    /// </summary>
    internal class QuestionManager : IQuestionManager
    {
        private List<Question> _questions; //список вопросов (редко такие данные целиком хранятся в приложении, поэтому таким образом мы изобразили запрос данных, которые где-то хранятся)

        public bool LoadQuestions()
        {
            _questions = new List<Question>();
            _questions.Add(new Question(0, "Question 1", new List<Answer>()
            {
                new Answer(0, "Answer 01 (true)", true),
                new Answer(1, "Answer 02 (false)", false)
            }));
            _questions.Add(new Question(1, "Question 2", new List<Answer>()
            {
                new Answer(2, "Answer 02 (true)", true),
                new Answer(3, "Answer 03 (true)", true)
            }));
            _questions.Add(new Question(2, "Question 3", new List<Answer>()
            {
                new Answer(4, "Answer 04 (true)", true),
                new Answer(5, "Answer 05 (false)", false),
                new Answer(5, "Answer 05 (true)", true)
            }));
            return true;
        }

        // получение списка доступных вопросов
        public List<int> GetQuestions()
        {
            var output = new List<int>();
            foreach (var question in _questions)
            {
                output.Add(question.Id);
            }
            return output;
        }

        // получение вопроса
        public Question GetQuestion(int id)
        {
            foreach (var question in _questions)
            {
                if (id == question.Id)
                {
                    return question;
                }
            }
            return null;
        }

        // проверка на правильность данного ответа
        public bool CalculateAnswers(Question question, int number)
        {
            return question.Answers[number].IsRight;
        }


        public void AddQuestion()
        {
            throw new NotImplementedException();
        }

        public void EditQuestion()
        {
            throw new NotImplementedException();
        }

        public void RemoveQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
