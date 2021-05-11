using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryContracts.Models
{
    public class AnsweredQuestion
    {
        [Key]
        public Guid AnsweredQuestionId { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("AnsweredQuizId")]
        public AnsweredQuiz Quiz { get; set; }

        [ForeignKey("QuizQuestionID")]
        public QuizQuestion Question { get; set; }

        [ForeignKey("QuizAnswerID")]
        public QuizAnswer QuizAnswer { get; set; }

        public string UserID { get; set; }

        public Guid AnsweredQuizId { get; set; }

        public Guid QuizQuestionID { get; set; }

        public Guid QuizAnswerID { get; set; }
    }
}
