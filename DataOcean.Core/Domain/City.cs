using System;
using System.Collections.Generic;

#nullable disable

namespace DataOcean.Core.Domain
{
    public partial class City
    {
        public int City_Code { get; set; }
        public int? Country_Code { get; set; }
        public string City_Name_English { get; set; }
        public string City_Name_Arabic { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public byte[] Updated_Date { get; set; }

        public virtual Country Country_CodeNavigation { get; set; }
    }
}
