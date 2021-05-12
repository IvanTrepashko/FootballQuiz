using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models
{
    public class AnsweredQuizModel
    {
        public string UserID { get; set; }

        public Guid AnsweredQuizModelID { get; set; }

        public QuizModel QuizModel { get; set; }

        public List<AnsweredQuestionModel> AnsweredQuestionModels { get; set; }

        public int Score { get; set; }
    }
}
