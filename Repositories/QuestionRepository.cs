using Microsoft.EntityFrameworkCore;
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
        public async void AddAnsweredQuestions(List<AnsweredQuestion> answers)
        {
            var context = new ApplicationContext();

            foreach (var answer in answers)
            {
                answer.UserID = answer.User.UserID;
                answer.User = null;

                answer.QuizAnswerID = answer.QuizAnswer.QuizAnswerID;
                answer.QuizAnswer = null;

                answer.AnsweredQuizId = answer.Quiz.AnsweredQuizId;
                answer.Quiz = null;

                answer.QuizQuestionID = answer.Question.QuizQuestionID;
                answer.Question = null;
            }

            await context.AnsweredQuestions.AddRangeAsync(answers);

            await context.SaveChangesAsync();
        }

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

        public List<QuizQuestion> GetQuestions(Guid quizID)
        {
            var context = new ApplicationContext();

            return context.QuizQuestions.Include(x => x.Answers).Where(x => x.QuizID.Equals(quizID)).ToList();
        }
    }
}
