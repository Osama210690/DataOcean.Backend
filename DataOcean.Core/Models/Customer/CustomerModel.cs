using System;
using DataOcean.Core.Models.City;
using DataOcean.Core.Models.Country;

namespace DataOcean.Core.Models.Customer
{
    public class CustomerModel
    {
        public CustomerModel()
        {
            Country = new CountryModel();

            City = new CityModel();
        }

        public int Customer_Code { get; set; }

        public string Name_English { get; set; }

        public string Name_Arabic { get; set; }

        public string Mobile_No { get; set; }

        public string Email { get; set; }

        public string Address_Line1 { get; set; }

        public string Address_Line2 { get; set; }

        public string Address_Line3 { get; set; }

        public CountryModel Country { get; set; }

        public CityModel City { get; set; }

    }
}
