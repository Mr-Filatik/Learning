using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsoleProject.Entities
{
    /// <summary>
    /// Ответ
    /// </summary>
    internal class Answer
    {
        internal int Id { get; set; }
        internal string Text { get; private set; }
        internal bool IsRight { get; private set; }

        public Answer(int id, string text, bool isRight)
        {
            Id = id;
            Text = text;
            IsRight = isRight;
        }
    }
}
