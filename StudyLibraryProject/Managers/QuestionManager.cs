using StudyLibraryProject.Abstract;
using StudyLibraryProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StudyLibraryProject.Managers
{
    /// <summary>
    /// сущность для взаимодействия с вопросами
    /// </summary>
    public class QuestionManager : IQuestionManager
    {
        private List<Question> _questions; //список вопросов (редко такие данные целиком хранятся в приложении, поэтому таким образом мы изобразили запрос данных, которые где-то хранятся)

        public bool LoadQuestions()
        {
            //вынес ответы отдельно для удобства
            var answers = new List<Answer>() 
            {
                new Answer(0, "Answer 11 (true)"),
                new Answer(1, "Answer 12 (false)"),
                new Answer(2, "Answer 23 (false)"),
                new Answer(3, "Answer 24 (true)"),
                new Answer(4, "Answer 35 (true)"),
                new Answer(5, "Answer 36 (false)"),
                new Answer(6, "Answer 37 (true)")
            };

            _questions = new List<Question>();
            _questions.Add(new OneRightQuestion(0, "Question 1", new List<Answer>()
            {
                answers[0],
                answers[1]
            }, 0));
            _questions.Add(new OneRightQuestion(1, "Question 2", new List<Answer>()
            {
                answers[2],
                answers[3]
            }, 3));
            _questions.Add(new SomeRightQuestion(2, "Question 3", new List<Answer>()
            {
                answers[4],
                answers[5],
                answers[6]
            }, new List<int> { 4, 6 } ));
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
        public bool CalculateAnswers(Question question)
        {
            return question.IsCorrectAnswer();
        }

        public void SetAnswer(Question question, int answerId)
        {
            question.SetAnswer(answerId);
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
