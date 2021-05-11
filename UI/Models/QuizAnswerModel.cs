using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class QuizAnswerModel
    {
        public Guid AnswerModelID { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }
    }
}
