using MediatR;
using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.UseCases.Shop.Queries
{
    public class GetShopsFilteredHandler : IRequestHandler<GetShopsFilteredModel, IQueryable<ShopDto>>
    {
        private readonly IReadOnlyShopRepository _shopRepository;

        public GetShopsFilteredHandler(IReadOnlyShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public Task<IQueryable<ShopDto>> Handle(GetShopsFilteredModel request, CancellationToken cancellationToken)
        {
            // Write *********************************
            // Init

            // Validation

            // Act

            // Save

            // Read **********************************
            IShopFilterBuilder builder = _shopRepository
                .FilterBuilder;

            builder = new NameStartsWithFilterParameter(request.Query.Filter).Compile(builder);
            builder = new NameEndsWithFilterParameter(request.Query.Filter).Compile(builder);
            // ...

            IQueryable<ShopDto> result = builder
                .Build()
                .Select(s => s.ToDto());

            return Task.FromResult(result);
        }
    }
}
