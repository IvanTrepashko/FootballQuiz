using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Models;

namespace TelegramBot.Services
{
    public class QuizService
    {
        private HttpClient client;

        public QuizService()
        {
            this.client = new HttpClient();
        }

        public async Task<AnsweredQuizModel> GetRandomQuizAsync()
        {
            return await this.client.GetFromJsonAsync<AnsweredQuizModel>("https://localhost:44333/api/QuizAnswer/random");
        }
    }
}
