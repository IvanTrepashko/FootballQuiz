using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models
{
    public class Quiz
    {
        public AnsweredQuizModel AnsweredQuizModel { get; set; }

        public long ChatId { get; set; }

        public int CurrentQuestion { get; set; }

        public int Score { get; set; }
    }
}
