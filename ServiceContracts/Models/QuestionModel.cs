using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Models
{
    public class QuestionModel
    {
        public string Question { get; set; }

        public List<AnswerModel> AnswerModels { get; set; }

        public DateTime CreationDate { get; set; }

        public string UserID { get; set; }

        public Guid QuizID { get; set; }
    }
}
