using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataOcean.Core.Domain;
using DataOcean.Core.Models.City;

namespace DataOcean.Core.Repositories.Core
{
    public interface ICityRepository
    {

        Task<List<City>> GetAllCities();

        Task<City> GetCityById(int cityCode);

        void Create(City country);

        void Delete(City country);
    }
}
