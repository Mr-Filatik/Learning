using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsoleProject.Entities
{
    /// <summary>
    /// Сущность для вопроса
    /// </summary>
    internal class Question
    {
        internal int Id { get; set; } // уникальный идентификатор для бд
        internal string Text { get; private set; } // текст ответа
        internal List<Answer> Answers { get; private set; } // список ответов

        internal Question(int id, string text, List<Answer> answers)
        {
            Id = id;
            Text = text;
            Answers = answers;
        }
    }
}
