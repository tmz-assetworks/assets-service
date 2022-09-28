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
    public class GetVechicleModelDDLQuery : IRequest<List<ListDropDown>>
    {       
    }
}
