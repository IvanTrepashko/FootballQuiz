using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class AnsweredQuestionModel
    {
        public QuestionModel QuestionModel { get; set; }

        public AnswerModel Answer { get; set; }

        public Guid AnswerModelID { get; set; }
    }
}
