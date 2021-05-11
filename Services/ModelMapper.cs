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

        public async Task<List<AnsweredQuestion>> MapModelAnswersAsync(AnsweredQuizModel value, AnsweredQuiz quiz)
        {
            List<AnsweredQuestion> answeredQuestions = new List<AnsweredQuestion>();

            foreach (var answeredQuestionModel in value.AnsweredQuestionModels)
            {
                var answeredQuestion = new AnsweredQuestion();
                answeredQuestion.AnsweredQuestionId = Guid.NewGuid();
                answeredQuestion.Quiz = quiz;
                answeredQuestion.User = await this.userRepository.GetByIDAsync(value.UserID);
                answeredQuestion.QuizAnswer = MapAnswerModel(answeredQuestionModel.Answer);
                answeredQuestion.Question = await MapQuestionModelAsync(answeredQuestionModel.QuestionModel);
                answeredQuestions.Add(answeredQuestion);
            }

            return answeredQuestions;
        }

        public async Task<AnsweredQuiz> MapAnsweredQuizModelAsync(AnsweredQuizModel value)
        {
            var answeredQuiz = new AnsweredQuiz();
            answeredQuiz.Quiz = await MapQuizModelAsync(value.QuizModel);
            answeredQuiz.AnsweredQuizId = Guid.NewGuid();
            answeredQuiz.User = await this.userRepository.GetByIDAsync(value.UserID);
            answeredQuiz.CompletionDate = DateTime.Now;

            answeredQuiz.Score = value.AnsweredQuestionModels.Count(x => x.Answer.IsCorrect);

            return answeredQuiz;
        }

        public async Task<QuizQuestion> MapQuestionModelAsync(QuestionModel questionModel)
        {
            QuizQuestion question = new();
            question.Creator = await this.userRepository.GetByIDAsync(questionModel.UserID);
            question.Question = questionModel.Question;
            question.Quiz = this.quizRepository.GetById(questionModel.QuizID);
            question.Answers = MapAnswerModels(questionModel.AnswerModels);
            question.CreatorUserID = question.Creator.UserID;
            question.QuizID = question.Quiz.QuizID;
            question.QuizQuestionID = questionModel.QuestionModelID;

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

        public AnsweredQuestionModel MapQuestion(QuizQuestion question)
        {
            var answeredQustionModel = new AnsweredQuestionModel();

            answeredQustionModel.QuestionModel = MapQuizQuestion(question);

            return answeredQustionModel;
        }

        public QuestionModel MapQuizQuestion(QuizQuestion question)
        {
            var questionModel = new QuestionModel();
            questionModel.Question = question.Question;
            questionModel.QuizID = question.QuizID;
            questionModel.UserID = question.CreatorUserID;
            questionModel.QuestionModelID = question.QuizQuestionID;
            questionModel.AnswerModels = MapAnswers(question.Answers);

            return questionModel;
        }

        public List<AnsweredQuizModel> MapAnsweredQuizzes(List<AnsweredQuiz> answeredQuizzes)
        {
            List<AnsweredQuizModel> answeredQuizModels = new List<AnsweredQuizModel>();
            foreach (var answeredQuiz in answeredQuizzes)
            {
                var answeredQuizModel = MapAnsweredQuiz(answeredQuiz);
                answeredQuizModels.Add(answeredQuizModel);
            }

            return answeredQuizModels;
        }

        public AnsweredQuizModel MapAnsweredQuiz(AnsweredQuiz answeredQuiz)
        {
            AnsweredQuizModel answeredQuizModel = new AnsweredQuizModel();
            answeredQuizModel.UserID = answeredQuiz.UserID;
            answeredQuizModel.QuizModel = MapQuiz(answeredQuiz.Quiz);
            answeredQuizModel.AnsweredQuizModelID = answeredQuiz.AnsweredQuizId;

            return answeredQuizModel;
        }

        public List<AnswerModel> MapAnswers(IEnumerable<QuizAnswer> answers)
        {
            List<AnswerModel> answerModels = new List<AnswerModel>();

            foreach (var answer in answers)
            {
                var answerModel = new AnswerModel();
                answerModel.AnswerText = answer.AnswerText;
                answerModel.IsCorrect = answer.IsCorrect;
                answerModel.AnswerModelID = answer.QuizAnswerID;

                answerModels.Add(answerModel);
            }

            return answerModels;
        }

        public List<QuizAnswer> MapAnswerModels(IEnumerable<AnswerModel> answerModels)
        {
            List<QuizAnswer> answers = new List<QuizAnswer>();
            foreach (var model in answerModels)
            {
                QuizAnswer answer = MapAnswerModel(model);
                answers.Add(answer);
            }

            return answers;
        }

        public QuizAnswer MapAnswerModel(AnswerModel model)
        {
            return new QuizAnswer
            {
                AnswerText = model.AnswerText,
                IsCorrect = model.IsCorrect,
                QuizAnswerID = model.AnswerModelID,
            };
        }
    }
}
