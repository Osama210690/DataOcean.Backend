using DataOcean.Core.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOcean.Core.Models.Country
{
    public class CountryModel
    {
        public CountryModel()
        {
            Cities = new List<CityModel>();
        }

        public int Country_Code { get; set; }

        public string Country_Name_English { get; set; }

        public string Country_Name_Arabic { get; set; }

        public List<CityModel> Cities { get; set; }
    }
}
