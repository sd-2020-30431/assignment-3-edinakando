using System.Threading.Tasks;
using WastelessAPI.Application.Shared;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.DataAccess.Repositories;

namespace WastelessAPI.Application.Logic
{
    public class UserLogic
    {
        private readonly UserRepository _userRepository;

        public UserLogic(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> InsertNewUser(User user)
        {
            if (await _userRepository.IsDuplicateUser(user))
            {
                return null;
            }

            user.Password = HashingSHA.GenerateSHA256String(user.Password);
            return await _userRepository.AddUser(user);
        }

        public async Task<User> GetValidUser(User user)
        {
            user.Password = HashingSHA.GenerateSHA256String(user.Password);
            return await _userRepository.GetValidUser(user);
        }
    }
}