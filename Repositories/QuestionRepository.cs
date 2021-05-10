using RepositoryContracts;
using RepositoryContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public async void AddQuestionAsync(QuizQuestion quizQuestion)
        {
            var context = new ApplicationContext();

            quizQuestion.Quiz = null;
            quizQuestion.Creator = null;

            await context.QuizQuestions.AddAsync(quizQuestion);
            await context.SaveChangesAsync();
        }

        public async void AddQuestionsAsync(IEnumerable<QuizQuestion> quizQuestions)
        {
            var context = new ApplicationContext();

            foreach (var quizQuestion in quizQuestions)
            {
                quizQuestion.Quiz = null;
                quizQuestion.Creator = null;

                await context.QuizQuestions.AddAsync(quizQuestion);
                await context.QuizAnswers.AddRangeAsync(quizQuestion.Answers);
                await context.SaveChangesAsync();
            }
        }
    }
}
