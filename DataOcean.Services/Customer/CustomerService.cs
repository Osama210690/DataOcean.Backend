using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataOcean.Core.Models.City;
using DataOcean.Core.Models.Country;
using DataOcean.Core.Models.Customer;
using DataOcean.Core.Repositories.Core;

namespace DataOcean.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;


        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerModel> CreateCustomer(CustomerModel model)
        {
            var entity = new Core.Domain.Customer()
            {
                Name_English = model.Name_English,
                Name_Arabic = model.Name_Arabic,
                Address_Line1 = model.Address_Line1,
                Address_Line2 = model.Address_Line2,
                Address_LIne3 = model.Address_Line3,
                City_Code = model.City.City_Code,
                Country_Code = model.Country.Country_Code,
                Email = model.Email,
                Mobile_No = model.Mobile_No
            };

            _unitOfWork.Customer.Create(entity);
            await _unitOfWork.DataOceanComplete();
            model.Customer_Code = entity.Customer_Code;

            return model;
        }

        public async Task<CustomerModel> DeleteCustomer(int customerCode)
        {
            var entity = await _unitOfWork.Customer.GetCustomerById(customerCode);

            _unitOfWork.Customer.Delete(entity);

            await _unitOfWork.DataOceanComplete();

            return new CustomerModel() { Customer_Code = entity.Customer_Code };
        }

        public async Task<List<CustomerModel>> GetAllCustomers()
        {
            var customers = await _unitOfWork.Customer.GetAllCustomers();

            return customers.Select(x => new CustomerModel()
            {
                Customer_Code=x.Customer_Code,
                Name_English = x.Name_English,
                Name_Arabic = x.Name_Arabic,
                Address_Line1 = x.Address_Line1,
                Address_Line2 = x.Address_Line2,
                Address_Line3 = x.Address_LIne3,
                City = new CityModel()
                {
                    City_Code = x.City_CodeNavigation.City_Code,
                    City_Name_English = x.City_CodeNavigation.City_Name_English

                },
                Country = new CountryModel()
                {
                    Country_Code = x.Country_CodeNavigation.Country_Code,
                    Country_Name_English = x.Country_CodeNavigation.Country_Name_English
                },
                Email = x.Email,
                Mobile_No = x.Mobile_No

            }).ToList();
        }

        public async Task<CustomerModel> UpdateCustomer(CustomerModel model)
        {
            var entity = await _unitOfWork.Customer.GetCustomerById(model.Customer_Code);

            entity.Customer_Code = model.Customer_Code;
            entity.Name_English= model.Name_English;
            entity.Name_Arabic = model.Name_Arabic;
            entity.Address_Line1 = model.Address_Line1;
            entity.Address_Line2 = model.Address_Line2;
            entity.Address_LIne3 = model.Address_Line3;
            entity.Email = model.Email;
            entity.Mobile_No = model.Mobile_No;
            entity.Country_Code = model.Country.Country_Code;
            entity.City_Code = model.City.City_Code;

            await _unitOfWork.DataOceanComplete();

            return model;
        }
    }
}
