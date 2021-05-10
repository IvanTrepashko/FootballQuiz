using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts.Models
{
    public class QuizAnswer
    {
        [Key]
        public Guid QuizAnswerID { get; set; }

        [ForeignKey("QuizQuestionID")]
        public QuizQuestion QuizQuestion { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public Guid QuizQuestionID { get; set; }
    }
}
