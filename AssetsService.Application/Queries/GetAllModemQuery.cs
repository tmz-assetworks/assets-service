using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetAllModemQuery :  IRequest<PagedList<ModemDTO>>
    {
        public ModemRequest _modemRequest = null;
        public GetAllModemQuery(ModemRequest modemRequest)
        {
            this._modemRequest = modemRequest;
        }
    }
}


