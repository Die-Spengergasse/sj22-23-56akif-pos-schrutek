using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Repository
{
    public class ShopRepository
    {
        private readonly SayonaraContext _context;

        public ShopRepository(SayonaraContext context)
        {
            _context = context;
        }

        public IQueryable<Shop> GetAll() 
        {
            return _context.Shops;
        }
    }
}
