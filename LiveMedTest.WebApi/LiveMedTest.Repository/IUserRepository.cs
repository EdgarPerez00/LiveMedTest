using LiveMedTest;
using LiveMedTest.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedTest.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<UserCountry>> GetUserCountries ();
    }
}
