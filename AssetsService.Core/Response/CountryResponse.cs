using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Responses.Assets
{

    public class AllCountryResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<CountryData> data { get; set; }
    }

    public class CountryData
    {
        public long Id { get; set; }
        public string CountryName { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public List<StateData> StateData { get; set; }
    }

    public class StateData
    {
        public long Id { get; set; }
        public long CountryId { get; set; }
        public string StateName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<CityData> CityData { get; set; }

    }
    public class CityData
    {
        public long Id { get; set; }
        public long StateId { get; set; }
        public string CityName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }

    public class StateByCountryIdResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<StateData> data { get; set; }

    }

    public class CityByStateIdResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<CityData> data { get; set; }

    }
}