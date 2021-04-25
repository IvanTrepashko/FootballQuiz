using System;
using System.ComponentModel.DataAnnotations;

namespace RepositoryContracts.Models
{
    public class AnsweredQuestion
    {
        [Key]
        public Guid AnsweredQuestionId { get; set; }

        public User User { get; set; }

        public AnsweredQuiz Quiz { get; set; }

        public string Question { get; set; }

        public QuizAnswer QuizAnswer { get; set; }
    }
}
