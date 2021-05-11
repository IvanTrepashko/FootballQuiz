using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Models
{
    public class DetailedAnsweredQuiz
    {
        public QuizModel QuizModel { get; set; }

        public List<AnsweredQuestionModel> AnsweredQuestionModels { get; set; }
    }
}
