using System.Text.Json;

namespace Worshipmaker.Core.Accounts
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

        /// <summary>
        /// Initialization constructor.
        /// </summary>
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

        /// <summary>
        /// Returns an address as serialized JSON.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Loads an address from serialized JSON.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public void FromJson(string json)
        {
            var obj = JsonSerializer.Deserialize<Address>(json);
            if (obj != null)
            {
                this.Address1 = obj.Address1;
                this.Address2 = obj.Address2;
                this.City = obj.City;
                this.RegionID = obj.RegionID;
                this.RegionName = obj.RegionName;
                this.PostalCode = obj.PostalCode;
                this.CountryID = obj.CountryID;
                this.CountryName = obj.CountryName;
                this.Phone = obj.Phone;
            }
        }
    }
}