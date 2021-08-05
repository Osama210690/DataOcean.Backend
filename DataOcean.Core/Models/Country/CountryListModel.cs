using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOcean.Core.Models.Country
{
    public class CountryListModel
    {
        public CountryListModel()
        {
            CountryList = new List<CountryModel>();
        }

        public List<CountryModel> CountryList { get; set; }
    }
}
