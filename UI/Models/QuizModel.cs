using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class QuizModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Имя слишком длинное")]
        [MinLength(6, ErrorMessage = "Имя слишком короткое")]
        public string Name { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Название темы слишком короткое")]
        public string Topic { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Название темы слишком короткое")]
        public string Description { get; set; }

        public string Tags { get; set; }

        public DateTime CreationDate { get; set; }

        public string UserID { get; set; }

        public Guid QuizID { get; set; }
    }
}
