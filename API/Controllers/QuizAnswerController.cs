using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizAnswerController : ControllerBase
    {
        private IQuizService quizService;

        public QuizAnswerController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        // GET: api/<QuizAnswerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("random")]
        public IActionResult GetRandomQuiz()
        {
            return new JsonResult(this.quizService.GetRandom());
        }

        // GET api/<QuizAnswerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuizAnswerController>
        [HttpPost]
        public void Post([FromBody] AnsweredQuizModel value)
        {
            this.quizService.AddAnsweredAsync(value);
        }

        // PUT api/<QuizAnswerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuizAnswerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
