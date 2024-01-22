using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLibraryProject.Entities
{
    /// <summary>
    /// Сущность для вопроса
    /// </summary>
    public class OneRightQuestion : Question
    {
        //переменные для работы вопроса с одним верным ответом
        private int RightAnswerId { get; init; }
        private int CurrentAnswerId { get; set; }

        public OneRightQuestion(int id, string text, List<Answer> answers, int rightAnswerId) : base(id, text, answers)
        {
            RightAnswerId = rightAnswerId;
            CurrentAnswerId = default;
        }

        //делаем реализацию для конкретного класса
        public override bool IsCorrectAnswer()
        {
            return RightAnswerId == CurrentAnswerId;
        }

        //делаем реализацию для конкретного класса
        public override void SetAnswer(int id)
        {
            bool isContains = false;
            foreach (var item in Answers)
            {
                if (item.Id == id)
                {
                    isContains = true;
                    break;
                }
            }

            if (isContains) 
            {
                CurrentAnswerId = id;
            }
            else
            {
                CurrentAnswerId = -1;
            }
        }
    }
}
