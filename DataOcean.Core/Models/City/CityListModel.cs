using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOcean.Core.Models.City
{
    public class CityListModel
    {
        public CityListModel()
        {
            CityList = new List<CityModel>();
        }

        public List<CityModel> CityList { get; set; }
    }
}
