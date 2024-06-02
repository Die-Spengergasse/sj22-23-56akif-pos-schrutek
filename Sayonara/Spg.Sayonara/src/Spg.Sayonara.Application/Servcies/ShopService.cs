using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Exceptions;
using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;

namespace Spg.Sayonara.Application.Servcies
{
    public class ShopService : IReadOnlyShopService
    {
        private readonly IReadOnlyShopRepository _shopRepository;

        public ShopService(IReadOnlyShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public IEnumerable<ShopDto> GetFiltered(GetShopsQuery query)
        {
            return _shopRepository
                .FilterBuilder
                .Build()
                .Select(s => s.ToDto());
        }

        public Shop GetSingle(string name)
        {
            try
            {
                return _shopRepository.GetSingle(name);
            }
            catch (RepositoryReadException ex)
            {
                throw ServiceReadException.FromNotFound(nameof(Shop), name, ex);
            }
        }


    }
}
