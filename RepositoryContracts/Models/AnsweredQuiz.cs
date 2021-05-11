using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts.Models
{
    public class AnsweredQuiz
    {
        [Key]
        public Guid AnsweredQuizId { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        public Quiz Quiz { get; set; }

        public DateTime CompletionDate { get; set; }

        public int Score { get; set; }

        public string UserID { get; set; }

        [Required]
        public Guid QuizID { get; set; }
    }
}
