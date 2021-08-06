using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataOcean.Core.Context;
using DataOcean.Core.Domain;
using DataOcean.Core.Models.City;
using DataOcean.Core.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace DataOcean.Core.Repositories.Persistence
{
    public class CityRepository : ICityRepository
    {
        private readonly DataOceanContext _dataOceanContext;


        public CityRepository(DataOceanContext dataOceanContext)
        {
            _dataOceanContext = dataOceanContext;
        }

        public void Create(City city)
        {
            _dataOceanContext.Cities.Add(city);

        }

        public void Delete(City city)
        {
            _dataOceanContext.Cities.Remove(city);

        }

        public Task<List<City>> GetAllCities()
        {
            return _dataOceanContext.Cities.Include(x => x.Country_CodeNavigation).ToListAsync();
        }

        public Task<City> GetCityById(int cityCode)
        {
           return _dataOceanContext.Cities
                .Include(x=>x.Country_CodeNavigation)
                .FirstOrDefaultAsync(x=>x.City_Code==cityCode);
        }

         
    }
}
