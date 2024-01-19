using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsoleProject.Entities
{
    /// <summary>
    /// Вопрос
    /// </summary>
    internal class Question
    {
        internal int Id { get; set; }
        internal string Text { get; private set; }
        internal List<Answer> Answers { get; private set; }

        internal Question(int id, string text, List<Answer> answers)
        {
            Id = id;
            Text = text;
            Answers = answers;
        }
    }
}
