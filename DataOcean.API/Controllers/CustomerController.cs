using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataOcean.Core.Models.Customer;
using DataOcean.Services.Customer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataOcean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService cutomerService)
        {
            _customerService = cutomerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cutomers = await _customerService.GetAllCustomers();

                return Ok(cutomers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerModel model)
        {
            try
            {

                var result = await _customerService.CreateCustomer(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerModel model)
        {
            try
            {

                var result = await _customerService.UpdateCustomer(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int customerCode)
        {
            try
            {
                var result = await _customerService.DeleteCustomer(customerCode);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
         
    }
}
