using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedTest.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository,
           ICountryRepository countryRepository)
        {
            User = userRepository;
            Country = countryRepository;
        }


        public IUserRepository User { get; }

        public ICountryRepository Country { get; }
    }
}
