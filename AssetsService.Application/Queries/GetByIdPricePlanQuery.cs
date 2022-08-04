using MediatR;
using AssetsService.Core.Entities;

namespace AssetsService.Core.Queries
{
   public class GetByIdPricePlanQuery : IRequest<PricePlan>
    {
        public long Id { get; set; }
        public GetByIdPricePlanQuery(int id)
        {
            Id = id;
        }
    }
}



