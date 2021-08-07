using System;
using System.Collections.Generic;

#nullable disable

namespace DataOcean.Core.Domain
{
    public partial class Customer
    {
        public int Customer_Code { get; set; }
        public string Name_English { get; set; }
        public string Name_Arabic { get; set; }
        public string Mobile_No { get; set; }
        public string Email { get; set; }
        public int? Country_Code { get; set; }
        public int? City_Code { get; set; }
        public string Address_Line1 { get; set; }
        public string Address_Line2 { get; set; }
        public string Address_LIne3 { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public byte[] Updated_Date { get; set; }

        public virtual City City_CodeNavigation { get; set; }
        public virtual Country Country_CodeNavigation { get; set; }
    }
}
