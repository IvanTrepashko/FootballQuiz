using RepositoryContracts;
using RepositoryContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public async void AddAsync(User user)
        {
            var context = new ApplicationContext();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIDAsync(string id)
        {
            var context = new ApplicationContext();
            var user = await context.Users.FindAsync(id);

            return user;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
