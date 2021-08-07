using System;
using System.Collections.Generic;

#nullable disable

namespace DataOcean.Core.Domain
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Customers = new HashSet<Customer>();
        }

        public int Country_Code { get; set; }
        public string Country_Name_English { get; set; }
        public string Country_Name_Arabic { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public byte[] Updated_Date { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
