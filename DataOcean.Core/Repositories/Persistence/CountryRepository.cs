using DataOcean.Core.Context;
using DataOcean.Core.Domain;
using DataOcean.Core.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOcean.Core.Repositories.Persistence
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataOceanContext _dataOceanContext;


        public CountryRepository(DataOceanContext dataOceanContext)
        {
            _dataOceanContext = dataOceanContext;
        }


        public virtual async Task<List<Country>> GetAllCountries()
        {
            return await _dataOceanContext.Countries.ToListAsync();
        }

        public virtual async Task<Country> GetCountryById(int countryCode)
        {
            return await _dataOceanContext.Countries
                .SingleOrDefaultAsync(x => x.Country_Code == countryCode);
        }

        public async Task Create(Country country)
        {

            await _dataOceanContext.Countries.AddAsync(country);

        }

    }
}
