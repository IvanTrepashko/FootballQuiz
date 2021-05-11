using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class QuestionModel
    {
        public string Question { get; set; }

        public List<QuizAnswerModel> AnswerModels { get; set; }

        public DateTime CreationDate { get; set; }

        public string UserID { get; set; }

        public Guid QuizID { get; set; }

        public QuestionModel()
        {
            this.AnswerModels = new List<QuizAnswerModel>();
        }
    }
}
