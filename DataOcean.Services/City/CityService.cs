using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataOcean.Core.Models.City;
using DataOcean.Core.Models.Country;
using DataOcean.Core.Repositories.Core;

namespace DataOcean.Services.City
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;


        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async  Task<CityModel> CreateCity(CityModel model)
        {
            var entity = new Core.Domain.City()
            {
                City_Name_English = model.City_Name_English,
                City_Name_Arabic = model.City_Name_Arabic,
                Country_Code = model.Country.Country_Code,
                
            };

            _unitOfWork.City.Create(entity);
            await _unitOfWork.DataOceanComplete();
            model.City_Code = entity.City_Code;

            return model;
        }

        public async Task<int> DeleteCity(int cityCode)
        {
            var entity = await _unitOfWork.City.GetCityById(cityCode);

            _unitOfWork.City.Delete(entity);

            await _unitOfWork.DataOceanComplete();

            return entity.City_Code;
        }

        public async Task<List<CityModel>> GetAllCities()
        {
            var cities = await _unitOfWork.City.GetAllCities();

            return cities.Select(x => new CityModel()
            {
                City_Code = x.City_Code,
                City_Name_Arabic=x.City_Name_Arabic,
                City_Name_English=x.City_Name_English,
                Country = new CountryModel()
                {
                    Country_Code=x.Country_CodeNavigation.Country_Code,
                    Country_Name_Arabic=x.Country_CodeNavigation.Country_Name_Arabic,
                    Country_Name_English=x.Country_CodeNavigation.Country_Name_English
                },

            }).ToList();
        }

        
        public async Task<CityModel> UpdateCity(CityModel model)
        {
            var entity = await _unitOfWork.City.GetCityById(model.City_Code);

            entity.City_Code = model.City_Code;
            entity.Country_Code = model.Country.Country_Code;
            entity.City_Name_Arabic = model.City_Name_Arabic;
            entity.City_Name_English = model.City_Name_English;

            await _unitOfWork.DataOceanComplete();

            return model;
        }
    }
}
