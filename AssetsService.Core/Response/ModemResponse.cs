

using AssetsService.Core.Entities;

namespace AssetsService.Core.Responses.Assets
{
public class AllModem{
        
        public int StatusCode;
        public string StatusMessage;

        public List<Modem> data{get;set;}
    }

    public class ModemById{
        
        public int StatusCode;
        public string StatusMessage;

        public Modem data{get;set;}
    }
}