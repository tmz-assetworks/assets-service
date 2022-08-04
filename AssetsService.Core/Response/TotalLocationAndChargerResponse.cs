using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Responses.Assets
{
    public class TotalLocationAndChargerResponse
    {
        public int  StatusCode { get; set; }

        public string StatusMessage { get; set; }
        public int TotalLocations { get; set; }
        public int TotalDispenser { get; set; }// Charger

    }

}