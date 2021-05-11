using RepositoryContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IQuizRepository
    {
        void Add(Quiz quiz);

        Task DeleteAsync(Guid quizId);

        Quiz GetById(Guid quizId);

        void Update(Quiz quiz);

        IEnumerable<Quiz> GetAll();

        List<Quiz> GetAllByUserId(string userId);
        
        Quiz GetRandomQuiz();
        void AddAnsweredAsync(AnsweredQuiz answeredQuiz);
    }
}
