using System;

namespace ServiceContracts.Models
{
    public class AnswerModel
    {
        public Guid AnswerModelID { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }
    }
}