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

        public ShopDto GetFilteredByName(string nameFilter)
        {
            return _shopRepository
                .FilterBuilder
                .ApplyNameContainsFilter(nameFilter)
                .Build()
                .SingleOrDefault() // ab hier NULL-Gefahr
                ?.ToDto()
                    ?? throw ServiceReadException.FromNotFound(nameof(Shop), nameFilter);
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
