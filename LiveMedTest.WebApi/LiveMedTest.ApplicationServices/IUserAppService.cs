using LiveMedTest.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedTest.ApplicationServices
{
    public interface IUserAppService
    {
        Task<IEnumerable<User>> Get();

        Task<int> Add(User user);

        Task Delete(int userId);

        Task Edit(User user);

        Task<User> Get(int userId);

        Task<IEnumerable<UserCountry>> GetUserCountries();
    }
}
