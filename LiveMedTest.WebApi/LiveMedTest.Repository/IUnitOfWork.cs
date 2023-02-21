using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedTest.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }

        ICountryRepository Country { get; }
    }
}
