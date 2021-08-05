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

        Task<Core.Domain.Country>  Create(CountryModel model);
    }
}
