using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts.Models
{
    public class Quiz
    {
        [Key]
        public Guid QuizID { get; set; }

        [ForeignKey("CreatorUserID")]
        public User Creator { get; set; }

        public string Name { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
        
        public string Tags { get; set; }
        
        [Required]
        public string CreatorUserID { get; set; }
    }
}
