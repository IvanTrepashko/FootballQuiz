using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Models
{
    public class AnsweredQuizModel
    {
        public string UserID { get; set; }

        public QuizModel QuizModel { get; set; }

        public Guid AnsweredQuizModelID { get; set; }

        public List<AnsweredQuestionModel> AnsweredQuestionModels { get; set; }

        public AnsweredQuizModel()
        {
            this.AnsweredQuestionModels = new List<AnsweredQuestionModel>();
        }
    }
}
