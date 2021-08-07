using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataOcean.Core.Models.City;
using DataOcean.Services.City;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataOcean.API.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cities = await _cityService.GetAllCities();

                return Ok(cities);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        var cities = await _cityService.GetAllCities();

        //        return Ok(cities);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CityModel model)
        {
            try
            {

                var result = await _cityService.CreateCity(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CityModel model)
        {
            try
            {

                var result = await _cityService.UpdateCity(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int cityCode)
        {
            try
            {

                var result = await _cityService.DeleteCity(cityCode);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
