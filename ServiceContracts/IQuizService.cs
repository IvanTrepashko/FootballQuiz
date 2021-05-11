using ServiceContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IQuizService
    {
        Task AddAsync(QuizModel quizModel);

        Task AddQuestionsAsync(IEnumerable<QuestionModel> questionModels);

        List<QuizModel> GetAllByUserId(string userId);

        void DeleteAsync(Guid id);
        
        Task UpdateAsync(QuizModel value);
        
        QuizModel GetById(Guid id);

        AnsweredQuizModel GetRandom();

        void AddAnsweredAsync(AnsweredQuizModel value);

        List<QuizModel> GetAll();

        AnsweredQuizModel GetAnsweredById(Guid quizId);
        List<AnsweredQuizModel> GetAnsweredByUserId(string userId);
    }
}
