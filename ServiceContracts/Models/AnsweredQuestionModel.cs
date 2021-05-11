using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Models
{
    public class AnsweredQuestionModel
    {
        public Guid AnswerModelID { get; set; }

        public QuestionModel QuestionModel { get; set; }

        public AnswerModel Answer { get; set; }
    }
}
