using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RepositoryContracts;
using Services;
using System;

namespace Services.Tests
{
    public class QuizServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ArgumentIsNull_Throws_ArgumentNullException()
        {
            var quizRepository = new Mock<IQuizRepository>();
            var userRepository = new Mock<IUserRepository>();
            var logger = new Mock<ILogger<QuizService>>();
            var questionRepository = new Mock<IQuestionRepository>();

            var modelMapper = new ModelMapper(userRepository.Object, quizRepository.Object);

            var quizService = new QuizService(quizRepository.Object, logger.Object, modelMapper, questionRepository.Object);

            Assert.Throws<ArgumentNullException>(()=>
            {
                quizService.AddAnsweredAsync(null);
            });
        }
    }
}