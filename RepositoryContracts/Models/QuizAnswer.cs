using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts.Models
{
    public class QuizAnswer
    {
        [Key]
        public Guid QuizAnswerID { get; set; }

        public QuizQuestion QuizQuestion { get; set; }

        public string AnswerTest { get; set; }

        public bool IsCorrect { get; set; }
    }
}
