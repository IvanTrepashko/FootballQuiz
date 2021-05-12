using System;

namespace TelegramBot.Models
{
    public class QuizModel
    {
        public string Name { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public DateTime CreationDate { get; set; }

        public string UserID { get; set; }

        public Guid QuizID { get; set; }
    }
}