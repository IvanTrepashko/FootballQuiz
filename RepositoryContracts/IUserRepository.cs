using RepositoryContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IUserRepository
    {
        Task<User> GetByIDAsync(string id);
        
        IEnumerable<User> GetAll();

        void AddAsync(User user);

        void Update(User user);

        void Delete(string id);
    }
}
