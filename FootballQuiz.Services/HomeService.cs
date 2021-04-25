using RepositoryContracts;
using ServiceContracts;
using System;

namespace Services
{
    public class HomeService : IHomeService
    {
        private IHomeRepository homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            this.homeRepository = homeRepository;
        }

        public string GetHello()
        {
            return homeRepository.GetHello();
        }
    }
}
