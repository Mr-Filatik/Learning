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
    public class SomeRightQuestion : Question
    {
        //переменные для работы вопроса с несколькими верными ответами
        private List<int> RightAnswerId { get; init; }
        public List<int> CurrentAnswerId { get; set; }

        public SomeRightQuestion(int id, string text, List<Answer> answers, List<int> rightAnswerId) : base(id, text, answers)
        {
            RightAnswerId = rightAnswerId;
            CurrentAnswerId = new List<int>();
        }

        //делаем реализацию для конкретного класса
        public override bool IsCorrectAnswer()
        {
            if (RightAnswerId.Count != CurrentAnswerId.Count)
            {
                return false;
            }
            foreach (var item in CurrentAnswerId)
            {
                if (!RightAnswerId.Contains(item))
                {
                    return false;
                }
            }
            foreach (var item in RightAnswerId)
            {
                if (!CurrentAnswerId.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }

        //делаем реализацию для конкретного класса
        public override void SetAnswer(int id)
        {
            if (CurrentAnswerId.Contains(id))
            {
                CurrentAnswerId.Remove(id);
                return;
            }

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
                CurrentAnswerId.Add(id);
            }
        }
    }
}
