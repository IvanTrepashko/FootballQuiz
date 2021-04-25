using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System.Linq;
using System.Text.Json;

namespace Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationContext context;

        public HomeRepository()
        {
            this.context = new ApplicationContext();
        }

        public string GetHello()
        {
            var quizzes = this.context.Quizes.Include(x => x.Creator);
            return JsonSerializer.Serialize(quizzes);
        }
    }
}
