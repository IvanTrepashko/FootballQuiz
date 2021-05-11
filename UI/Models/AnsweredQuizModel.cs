using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class AnsweredQuizModel
    {
        public string UserID { get; set; }

        public QuizModel QuizModel { get; set; }

        public List<AnsweredQuestionModel> AnsweredQuestionModels { get; set; }
    }
}
