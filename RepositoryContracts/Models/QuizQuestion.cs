using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts.Models
{
    public class QuizQuestion
    {
        [Key]
        public Guid QuizQuestionID { get; set; }

        [ForeignKey("CreatorUserID")]
        public User Creator { get; set; }

        [ForeignKey("QuizID")]
        public Quiz Quiz { get; set; }

        public string Question { get; set; }

        public List<QuizAnswer> Answers { get; set; }

        public Guid QuizID { get; set; }

        public string CreatorUserID { get; set; }
    }
}
