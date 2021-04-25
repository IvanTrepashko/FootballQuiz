using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts.Models
{
    public class AnsweredQuiz
    {
        [Key]
        public Guid AnsweredQuizId { get; set; }

        public User User { get; set; }

        public User Creator { get; set; }

        public string Topic { get; set; }

        public DateTime AnswerDate { get; set; }

        public string Tags { get; set; }
    }
}
