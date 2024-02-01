using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLibraryProject.Entities
{
    /// <summary>
    /// Сущность для ответов
    /// </summary>
    public class Answer
    {
        public int Id { get; set; } // уникальный идентификатор для бд
        public string Text { get; set; } // текст ответа

        public Answer(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
