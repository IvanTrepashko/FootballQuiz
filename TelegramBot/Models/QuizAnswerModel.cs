using System;

namespace TelegramBot.Models
{
    public class QuizAnswerModel
    {
        public string Number { get; set; }

        public Guid AnswerModelID { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }
    }
}