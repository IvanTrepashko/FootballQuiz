using RepositoryContracts.Models;
using ServiceContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IUserService
    {
        Task<User> GetAsync(string id);

        void Add(UserModel userModel);
    }
}
