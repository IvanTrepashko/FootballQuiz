using RepositoryContracts;
using System.Linq;

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
            return this.context.Quizes.FirstOrDefault()?.Topic;
        }
    }
}
