using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts.Models
{
    public class Quiz
    {
        public Guid QuizID { get; set; }

        public Guid CreatorID { get; set; }

        public string Topic { get; set; }

        public DateTime CreationDate { get; set; }
        
        public string Tags { get; set; }
    }
}
