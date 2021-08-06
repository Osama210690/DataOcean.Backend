using DataOcean.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOcean.Core.Repositories.Core
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();

        Task<Country> GetCountryById(int countryCode);

        void Create(Country country);

        void Delete(Country country);
    }
}
