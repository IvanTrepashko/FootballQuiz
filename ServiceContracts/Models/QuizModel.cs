using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceContracts.Models
{
    public class QuizModel
    {
        public string Name { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public DateTime CreationDate { get; set; }

        public string UserID { get; set; }

        public Guid QuizID { get; set; }
    }
}
