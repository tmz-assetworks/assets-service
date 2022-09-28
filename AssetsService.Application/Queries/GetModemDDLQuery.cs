using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
using AssetsService.Core.Responses.Assets;
using AssetsService.Core.PagingHelper;

namespace AssetsService.Application.Queries
{
    public class GetModemDDLQuery : IRequest<List<ListDropDown>>
    {
        public string userId { get; set; }
        public GetModemDDLQuery(string userId)
        {
            this.userId = userId;
        }
    }

}
