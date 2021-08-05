using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOcean.Core.Repositories.Core
{
   public interface IUnitOfWork
    {
        ICountryRepository Country { get; }

        void DisposeContext();

        Task DataOceanComplete();
    }
}
