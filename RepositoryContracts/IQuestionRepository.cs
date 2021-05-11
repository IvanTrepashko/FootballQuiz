using RepositoryContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IQuestionRepository
    {
        void AddQuestionAsync(QuizQuestion quizQuestion);

        void AddQuestionsAsync(IEnumerable<QuizQuestion> quizQuestions);
        
        List<QuizQuestion> GetQuestions(Guid quizID);

        void AddAnsweredQuestions(List<AnsweredQuestion> answers);
    }
}
