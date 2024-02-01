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
    public abstract class Question //сделал класс абстрактным, у нас будут вопросы с одним ответом и несколькими, а просто вопрос является абстракцией
    {
        public int Id { get; set; } // уникальный идентификатор для бд
        public string Text { get; set; } // текст ответа
        public List<Answer> Answers { get; set; } // список ответов

        public Question(int id, string text, List<Answer> answers)
        {
            Id = id;
            Text = text;
            Answers = answers;
        }

        //методы которые мы пока не можем сделать полноценно
        public abstract bool IsCorrectAnswer();
        public abstract void SetAnswer(int id);
    }
}
