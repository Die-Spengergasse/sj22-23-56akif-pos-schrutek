using MediatR;
using Spg.Sayonara.DomainModel.Dtos;

namespace Spg.Sayonara.Application.UseCases.Shop.Queries
{
    // https://code-maze.com/cqrs-mediatr-in-aspnet-core/
    public class GetShopsFilteredModel : IRequest<IQueryable<ShopDto>>
    {
        //public string Filter { get; set; }
        //public string OrderBy { get; set; }
        public GetShopsFilteredQuery Query { get; }

        public GetShopsFilteredModel(GetShopsFilteredQuery query)
        {
            Query = query;
        }
    }
}
