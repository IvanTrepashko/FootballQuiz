﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceContracts;
using ServiceContracts.Models;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ILogger<QuizController> logger;
        private readonly IQuizService quizService;

        public QuizController(ILogger<QuizController> logger, IQuizService quizService)
        {
            this.logger = logger;
            this.quizService = quizService;
        }

        // GET: api/<QuizController>
        [HttpGet]
        public JsonResult Get(string userId)
        {
            List<QuizModel> quizzes = this.quizService.GetAllByUserId(userId);

            return new JsonResult(quizzes);
        }

        // GET api/<QuizController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var quiz = this.quizService.GetById(id);
            return new JsonResult(quiz);
        }

        // POST api/<QuizController>
        [HttpPost]
        public void Post([FromBody] QuizModel value)
        {
            this.logger.LogInformation(value.Description);

            this.quizService.AddAsync(value);
        }

        [HttpPost]
        [Route("answers")]
        public async void PostAnswers([FromBody] List<QuestionModel> questionModels)
        {
            this.logger.LogInformation("Questions posted.");

            await this.quizService.AddQuestionsAsync(questionModels);
        }

        // PUT api/<QuizController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] QuizModel value)
        {
            this.quizService.UpdateAsync(value);
        }

        // DELETE api/<QuizController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this.quizService.DeleteAsync(id);
        }
    }
}