using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts.Models
{
    public class QuizQuestion
    {
        [Key]
        public Guid QuizQuestionID { get; set; }

        public User Creator { get; set; }

        public Quiz Quiz { get; set; }

        public string Question { get; set; }
    }
}
