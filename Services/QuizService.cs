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

        public async Task UpdateAsync(QuizModel value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var quiz = await this.modelMapper.MapQuizModelAsync(value);

            this.quizRepository.Update(quiz);
        }
    }
}
