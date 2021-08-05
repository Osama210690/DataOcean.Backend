using DataOcean.Core.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOcean.Core.Models.City
{
    public class CityModel
    {
        public CityModel()
        {
            Country = new CountryModel();
        }

        public int City_Code { get; set; }

        public string City_Name_English { get; set; }

        public string City_Name_Arabic { get; set; }

        public CountryModel Country { get; set; }

    }
}
