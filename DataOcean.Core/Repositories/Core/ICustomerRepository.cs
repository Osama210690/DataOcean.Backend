using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataOcean.Core.Domain;

namespace DataOcean.Core.Repositories.Core
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();

        Task<Customer> GetCustomerById(int customerCode);

        void Create(Customer country);

        void Delete(Customer country);
    }
}
