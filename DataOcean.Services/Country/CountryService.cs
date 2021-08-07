using DataOcean.Core.Models.Country;
using DataOcean.Core.Repositories.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataOcean.Services.Country
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;


        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CountryModel> CreateCountry(CountryModel model)
        {

            var entity = new Core.Domain.Country()
            {
                Country_Name_English = model.Country_Name_English,
                Country_Name_Arabic = model.Country_Name_English
            };


            _unitOfWork.Country.Create(entity);
            await _unitOfWork.DataOceanComplete();
            model.Country_Code = entity.Country_Code;

            return model;
        }

        public async Task<CountryModel> UpdateCountry(CountryModel model)
        {

            var entity = await _unitOfWork.Country.GetCountryById(model.Country_Code);

            entity.Country_Code = model.Country_Code;
            entity.Country_Name_Arabic = model.Country_Name_Arabic;
            entity.Country_Name_English = model.Country_Name_English;

            await _unitOfWork.DataOceanComplete();

            return model;
        }

        public async Task<List<CountryModel>> GetAllCountries()
        {
            var countries = await _unitOfWork.Country.GetAllCountries();

            return countries.Select(x => new CountryModel()
            {
                Country_Code = x.Country_Code,
                Country_Name_Arabic = x.Country_Name_Arabic,
                Country_Name_English = x.Country_Name_English

            }).ToList();
        }

        public async Task<CountryModel> DeleteCountry(int countryCode)
        {
            var entity = await _unitOfWork.Country.GetCountryById(countryCode);

            _unitOfWork.Country.Delete(entity);

            await _unitOfWork.DataOceanComplete();

            return new CountryModel() { Country_Code = entity.Country_Code };
        }
    }
}
