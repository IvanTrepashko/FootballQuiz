using RepositoryContracts;
using RepositoryContracts.Models;
using ServiceContracts;
using ServiceContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ModelMapper
    {
        private readonly IUserRepository userRepository;
        private readonly IQuizRepository quizRepository;

        public ModelMapper(IUserRepository userRepository, IQuizRepository quizRepository)
        {
            this.userRepository = userRepository;
            this.quizRepository = quizRepository;
        }

        public User MapUserModel(UserModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserID = model.UserID
            };

            return user;
        }

        public async Task<Quiz> MapQuizModelAsync(QuizModel model)
        {
            Quiz quiz = new()
            {
                CreationDate = model.CreationDate,
                Name = model.Name,
                Description = model.Description,
                Tags = model.Tags,
                Topic = model.Topic,
                QuizID = model.QuizID,
                Creator = await this.userRepository.GetByIDAsync(model.UserID)
            };

            return quiz;
        }

        public async Task<QuizQuestion> MapQuestionModelAsync(QuestionModel questionModel)
        {
            QuizQuestion question = new();
            question.Creator = await this.userRepository.GetByIDAsync(questionModel.UserID);
            question.Question = questionModel.Question;
            question.Quiz = this.quizRepository.GetById(questionModel.QuizID);
            question.Answers = MapAnswerModel(questionModel.AnswerModels);
            question.CreatorUserID = question.Creator.UserID;
            question.QuizID = question.Quiz.QuizID;
            question.QuizQuestionID = Guid.NewGuid();

            foreach (var answer in question.Answers)
            {
                answer.QuizQuestion = question;
            }

            return question;
        }

        public List<QuizModel> MapQuizzes(List<Quiz> quizzes)
        {
            var quizModels = new List<QuizModel>();

            foreach (var quiz in quizzes)
            {
                QuizModel model = MapQuiz(quiz);

                quizModels.Add(model);
            }

            return quizModels;
        }

        public QuizModel MapQuiz(Quiz quiz)
        {
            var model = new QuizModel();
            model.CreationDate = quiz.CreationDate;
            model.Name = quiz.Name;
            model.Tags = quiz.Tags;
            model.Topic = quiz.Topic;
            model.Description = quiz.Description;
            model.QuizID = quiz.QuizID;
            model.UserID = quiz.CreatorUserID;
            return model;
        }

        public List<QuizAnswer> MapAnswerModel(IEnumerable<AnswerModel> answerModels)
        {
            List<QuizAnswer> answers = new List<QuizAnswer>();
            foreach (var model in answerModels)
            {
                QuizAnswer answer = new QuizAnswer
                {
                    AnswerText = model.AnswerText,
                    IsCorrect = model.IsCorrect,
                    QuizAnswerID = Guid.NewGuid()
                };

                answers.Add(answer);
            }

            return answers;
        }
    }
}
