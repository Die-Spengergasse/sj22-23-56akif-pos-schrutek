using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.Servcies
{
    public class ShopService
    {
        private readonly ShopRepository _shopRepository;

        public ShopService(ShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public IQueryable<Shop> GetAll()
        {
            return _shopRepository.GetAll();
        }
    }
}
