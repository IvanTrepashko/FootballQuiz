using RepositoryContracts;
using RepositoryContracts.Models;
using ServiceContracts;
using ServiceContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ModelMapper modelMapper;

        public UserService(IUserRepository userRepository, ModelMapper modelMapper)
        {
            this.userRepository = userRepository;
            this.modelMapper = modelMapper;
        }

        public void Add(UserModel userModel)
        {
            if (userModel is null)
            {
                throw new ArgumentNullException(nameof(userModel));
            }

            var user = this.modelMapper.MapUserModel(userModel);

            this.userRepository.AddAsync(user);
        }

        public async Task<User> GetAsync(string id)
        {
            var user = await this.userRepository.GetByIDAsync(id);

            if (user is null)
            {

            }

            return user;
        }
    }
}
