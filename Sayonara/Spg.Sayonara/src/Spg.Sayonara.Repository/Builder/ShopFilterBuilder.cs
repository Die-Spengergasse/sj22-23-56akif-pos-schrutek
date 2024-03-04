using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Repository.Builder
{
    public class ShopFilterBuilder : IShopFilterBuilder
    {
        public IQueryable<Shop> EntityList { get; set; }

        public ShopFilterBuilder(IQueryable<Shop> shops)
        {
            EntityList = shops;
        }

        public IShopFilterBuilder ApplyNameContainsFilter(string namePart)
        {
            EntityList = EntityList.Where(p => p.Name.ToLower().Contains(namePart.ToLower()));
            return this;
        }

        public IQueryable<Shop> Build()
        {
            return EntityList;
        }
    }
}
