using Spg.Sayonara.DomainModel.Exceptions;
using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.Servcies
{
    public class ShopService : IReadOnlyShopService
    {
        private readonly IReadOnlyShopRepository _shopRepository;

        public ShopService(IReadOnlyShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public IQueryable<Shop> GetAll()
        {
            return _shopRepository.GetAll();
        }


        public Shop GetSingle(int id)
        {
            try
            {
                return _shopRepository.GetSingle(id);
            }
            catch (RepositoryReadException ex)
            {
                throw ServiceReadException.FromNotFound(ex);
            }
        }
    }
}
