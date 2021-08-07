using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataOcean.Core.Models.City;

namespace DataOcean.Services.City
{
    public interface ICityService
    {
        Task<List<CityModel>> GetAllCities();
        Task<CityModel> CreateCity(CityModel model);
        Task<CityModel> UpdateCity(CityModel model);
        Task<CityModel> DeleteCity(int cityCode);
    }
}
