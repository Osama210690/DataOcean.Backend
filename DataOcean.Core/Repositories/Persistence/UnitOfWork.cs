using DataOcean.Core.Context;
using DataOcean.Core.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOcean.Core.Repositories.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly DataOceanContext _dataOceanContext;

        public UnitOfWork(DataOceanContext dataOceanContext)
        {
            _dataOceanContext = dataOceanContext;

            Country = new CountryRepository(_dataOceanContext);
            City = new CityRepository(_dataOceanContext);
        }

        public ICountryRepository Country { get; }

        public ICityRepository City { get; }

         
        public void Dispose()
        {
            _dataOceanContext?.Dispose();
        }

        public void DisposeContext()
        {
            this.Dispose();
        }

        
        public async Task DataOceanComplete()
        {
             await _dataOceanContext.SaveChangesAsync();
        }
    }
}
