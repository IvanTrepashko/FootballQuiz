using System;

namespace TelegramBot.Models
{
    public class AnsweredQuestionModel
    {
        public QuestionModel QuestionModel { get; set; }

        public AnswerModel Answer { get; set; }

        public Guid AnswerModelID { get; set; }
    }
}