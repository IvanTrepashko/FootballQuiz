using RepositoryContracts;
using System;

namespace Repositories
{
    public class HomeRepository : IHomeRepository
    {
        public string GetHello()
        {
            return "Hello world";
        }
    }
}
