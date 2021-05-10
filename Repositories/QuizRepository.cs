using Microsoft.Extensions.Logging;
using RepositoryContracts;
using RepositoryContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ILogger<QuizRepository> logger;

        public QuizRepository(ILogger<QuizRepository> logger)
        {
            this.logger = logger;
        }

        public async void Add(Quiz quiz)
        {
            this.logger.LogInformation("QuizRepository \"Add\" method called");
            var context = new ApplicationContext();

            quiz.CreatorUserID = quiz.Creator.UserID;
            quiz.Creator = null;

            context.Quizes.Add(quiz);
            await context.SaveChangesAsync();

            this.logger.LogInformation("Quiz was added");
        }

        public async Task DeleteAsync(Guid quizId)
        {
            var context = new ApplicationContext();
            context.Quizes.Remove(GetById(quizId));
            await context.SaveChangesAsync();
        }

        public IEnumerable<Quiz> GetAll()
        {
            var context = new ApplicationContext();

            return context.Quizes;
        }

        public List<Quiz> GetAllByUserId(string userId)
        {
            var context = new ApplicationContext();

            return context.Quizes.Where(x => x.CreatorUserID.Equals(userId)).ToList();
        }

        public Quiz GetById(Guid quizId)
        {
            var context = new ApplicationContext();

            return context.Quizes.Find(quizId);
        }

        public async void Update(Quiz quiz)
        {
            var context = new ApplicationContext();

            context.Quizes.Update(quiz);

            await context.SaveChangesAsync();
        }
    }
}
