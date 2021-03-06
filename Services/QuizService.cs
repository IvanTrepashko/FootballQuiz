using Microsoft.Extensions.Logging;
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
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository quizRepository;
        private readonly ILogger<QuizService> logger;
        private readonly ModelMapper modelMapper;
        private readonly IQuestionRepository questionRepository;

        public QuizService(IQuizRepository quizRepository, ILogger<QuizService> logger, 
            ModelMapper modelMapper, IQuestionRepository questionRepository)
        {
            this.quizRepository = quizRepository;
            this.logger = logger;
            this.modelMapper = modelMapper;
            this.questionRepository = questionRepository;
        }

        public async void AddAnsweredAsync(AnsweredQuizModel value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            AddAnswersToAnsweredQuizModel(value);

            AnsweredQuiz answeredQuiz = await this.modelMapper.MapAnsweredQuizModelAsync(value);

            this.quizRepository.AddAnsweredAsync(answeredQuiz);
            List<AnsweredQuestion> answers = await this.modelMapper.MapModelAnswersAsync(value, answeredQuiz);

            this.questionRepository.AddAnsweredQuestions(answers);
        }

        private void AddAnswersToAnsweredQuizModel(AnsweredQuizModel answeredQuizModel)
        {
            foreach (var answer in answeredQuizModel.AnsweredQuestionModels)
            {
                answer.Answer = answer.QuestionModel.AnswerModels.Where(x => x.AnswerModelID.Equals(answer.AnswerModelID)).FirstOrDefault();
            }
        }

        public async Task AddAsync(QuizModel quizModel)
        {
            var quiz = await this.modelMapper.MapQuizModelAsync(quizModel);

            this.quizRepository.Add(quiz);
        }

        public async Task AddQuestionsAsync(IEnumerable<QuestionModel> questionModels)
        {
            List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
            foreach (var questionModel in questionModels)
            {
                var question = await this.modelMapper.MapQuestionModelAsync(questionModel);
                quizQuestions.Add(question);
            }

            this.questionRepository.AddQuestionsAsync(quizQuestions);
        }

        public void DeleteAsync(Guid id)
        {
            this.quizRepository.DeleteAsync(id);
        }

        public List<QuizModel> GetAllByUserId(string userId)
        {
            var quizzes = this.quizRepository.GetAllByUserId(userId);

            return this.modelMapper.MapQuizzes(quizzes);
        }

        public QuizModel GetById(Guid id)
        {
            var quiz = this.quizRepository.GetById(id);

            var quizModel = this.modelMapper.MapQuiz(quiz);

            return quizModel;
        }

        public AnsweredQuizModel GetRandom()
        {
            var answeredQuizModel = new AnsweredQuizModel();
            var quiz = this.quizRepository.GetRandomQuiz();
            CreateAnsweredQuizModel(answeredQuizModel, quiz);

            return answeredQuizModel;
        }

        private void CreateAnsweredQuizModel(AnsweredQuizModel answeredQuizModel, Quiz quiz)
        {
            answeredQuizModel.QuizModel = this.modelMapper.MapQuiz(quiz);

            var questions = this.questionRepository.GetQuestions(quiz.QuizID);

            foreach (var question in questions)
            {
                answeredQuizModel.AnsweredQuestionModels.Add(this.modelMapper.MapQuestion(question));
            }
        }

        public async Task UpdateAsync(QuizModel value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var quiz = await this.modelMapper.MapQuizModelAsync(value);

            this.quizRepository.Update(quiz);
        }

        public List<QuizModel> GetAll()
        {
            var quizzes = this.quizRepository.GetAll().ToList();

            var quizModels = this.modelMapper.MapQuizzes(quizzes);

            return quizModels;
        }

        public AnsweredQuizModel GetAnsweredById(Guid quizId)
        {
            var quiz = this.quizRepository.GetById(quizId);
            var answeredQuizModel = new AnsweredQuizModel();

            CreateAnsweredQuizModel(answeredQuizModel, quiz);

            return answeredQuizModel;
        }

        public List<AnsweredQuizModel> GetAnsweredByUserId(string userId)
        {
            List<AnsweredQuiz> answeredQuizzes = this.quizRepository.GetAnsweredByUserId(userId);

            List<AnsweredQuizModel> answeredQuizModels = this.modelMapper.MapAnsweredQuizzes(answeredQuizzes);

            return answeredQuizModels;
        }

        public DetailedAnsweredQuiz GetDetailedInfo(Guid quizId)
        {
            var detailedAnsweredQuiz = new DetailedAnsweredQuiz();

            AnsweredQuiz answeredQuiz = this.quizRepository.GetAnsweredById(quizId);

            detailedAnsweredQuiz.QuizModel = this.modelMapper.MapQuiz(this.quizRepository.GetById(answeredQuiz.QuizID));
            var answeredQuestions = this.questionRepository.GetAnsweredQuestions(quizId);

            detailedAnsweredQuiz.AnsweredQuestionModels = this.modelMapper.MapAnsweredQuestions(answeredQuestions);

            return detailedAnsweredQuiz;
        }

        public List<QuizModel> GetByTags(string[] quizTags)
        {
            List<Quiz> quizzes = this.quizRepository.GetByTags(quizTags);

            var quizModels = this.modelMapper.MapQuizzes(quizzes);

            return quizModels;
        }
    }
}
