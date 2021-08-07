using DataOcean.Core.Models.City;
using DataOcean.Core.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOcean.Services.Country
{
    public interface ICountryService
    {
        Task<List<CountryModel>> GetAllCountries();
        Task<CountryModel> CreateCountry(CountryModel model);
        Task<CountryModel> UpdateCountry(CountryModel model);
        Task<CountryModel> DeleteCountry(int countryCode);

    }
}
