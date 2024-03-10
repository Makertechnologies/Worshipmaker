using Newtonsoft.Json;

namespace Worshipmaker.Common.People
{
    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string PostalCode { get; set; }
        public string CountryID { get; set; }
        public string CountryName { get; set; }
        public string Phone { get; set; }

        public Address()
        {
            this.Address1 = "";
            this.Address2 = "";
            this.City = "";
            this.RegionID = "";
            this.RegionName = "";
            this.PostalCode = "";
            this.CountryID = "";
            this.CountryName = "";
            this.Phone = "";
        }

        public Address(string json) : base()
        {
//this= JsonConvert.DeserializeObject<Address>(json);
//if (address != null)
//{
//    this.Address1 = address.Address1;
//    this.Address2 = address.Address2;
//    this.City = address.City;
//    this.RegionID = address.RegionID;
//    this.RegionName = address.RegionName;
//    this.PostalCode = address.PostalCode;
//    this.CountryID = address.CountryID;
//    this.CountryName = address.CountryName;
//    this.Phone = address.Phone;
//}
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string ToHtml()
        {
            // TODO2024 Output to HTML
            return "";
        }
    }
}