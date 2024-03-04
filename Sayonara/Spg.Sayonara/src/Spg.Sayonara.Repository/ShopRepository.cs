using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IQueryable<Shop> GetAll()
        {
            return _context.Shops;
        }
    }
}
