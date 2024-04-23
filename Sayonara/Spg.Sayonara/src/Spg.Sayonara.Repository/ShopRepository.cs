using Spg.Sayonara.DomainModel.Exceptions;
using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository.Builder;

namespace Spg.Sayonara.Repository
{
    public class ShopRepository : IReadOnlyShopRepository
    {
        private readonly SayonaraContext _context;

        public IShopFilterBuilder FilterBuilder { get; set; }

        public ShopRepository(SayonaraContext context)
        {
            _context = context;

            FilterBuilder = new ShopFilterBuilder(_context.Shops);
        }

        public Shop GetSingle(string name)
        {
            return _context.Shops.SingleOrDefault(s => s.Name == name) 
                ?? throw RepositoryReadException.FromNotFound();
        }
    }
}
