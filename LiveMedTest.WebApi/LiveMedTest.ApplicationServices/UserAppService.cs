using LiveMedTest.Dto;
using LiveMedTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedTest.ApplicationServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository) 
        { 
            _userRepository= userRepository;
        }

        public async Task<int> Add(User user)
        {
           var result = await _userRepository.AddAsync(user);
            return result;
        }

        public async Task Delete(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task Edit(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task<IEnumerable<User>> Get()
        {

            return await _userRepository.GetAllAsync();
        }

        public async Task<User> Get(int userId)
        {
            var result = await _userRepository.GetByIdAsync(userId);
            return result;
        }

        public async Task<IEnumerable<UserCountry>> GetUserCountries()
        {
            var result = await _userRepository.GetUserCountries();
            return result;
        }
    }
}
