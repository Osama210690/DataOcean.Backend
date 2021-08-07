using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataOcean.Core.Context;
using DataOcean.Core.Domain;
using DataOcean.Core.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace DataOcean.Core.Repositories.Persistence
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly DataOceanContext _dataOceanContext;

        public CustomerRepository(DataOceanContext dataOceanContext)
        {
            _dataOceanContext = dataOceanContext;

        }

        public void Create(Customer country)
        {
            _dataOceanContext.Customers.Add(country);

        }

        public void Delete(Customer country)
        {
            _dataOceanContext.Customers.Remove(country);

        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _dataOceanContext.Customers
                .Include(x=>x.Country_CodeNavigation)
                .Include(x=>x.City_CodeNavigation)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int customerCode)
        {
            return await _dataOceanContext.Customers
                .SingleOrDefaultAsync(x => x.Customer_Code == customerCode);
        }
    }
}
