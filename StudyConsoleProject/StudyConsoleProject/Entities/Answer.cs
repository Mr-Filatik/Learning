using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsoleProject.Entities
{
    /// <summary>
    /// Сущность для ответов
    /// </summary>
    internal class Answer
    {
        internal int Id { get; set; } // уникальный идентификатор для бд
        internal string Text { get; private set; } // текст ответа
        internal bool IsRight { get; private set; } // правильный ли ответ

        public Answer(int id, string text, bool isRight)
        {
            Id = id;
            Text = text;
            IsRight = isRight;
        }
    }
}
