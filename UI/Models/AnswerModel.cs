using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class AnswerModel
    {
        public Guid AnswerModelID { get; set; }

        public QuizAnswerModel QuizAnswerModel { get; set; }

        public bool IsChosen { get; set; }
    }
}
