using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataOcean.Core.Models.Customer;

namespace DataOcean.Services.Customer
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetAllCustomers();
        Task<CustomerModel> CreateCustomer(CustomerModel model);
        Task<CustomerModel> UpdateCustomer(CustomerModel model);
        Task<CustomerModel> DeleteCustomer(int customerCode);

    }
}
