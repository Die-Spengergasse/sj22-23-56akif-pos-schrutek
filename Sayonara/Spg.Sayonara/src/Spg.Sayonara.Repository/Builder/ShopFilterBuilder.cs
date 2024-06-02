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
        public IShopFilterBuilder ApplyNameStartsWithFilter(string namePart)
        {
            EntityList = EntityList.Where(p => p.Name.ToLower().StartsWith(namePart.ToLower()));
            return this;
        }
        public IShopFilterBuilder ApplyNameEndWithFilter(string namePart)
        {
            EntityList = EntityList.Where(p => p.Name.ToLower().EndsWith(namePart.ToLower()));
            return this;
        }
        public IShopFilterBuilder ApplyCompanySuffixContainsFilter(string namePart)
        {
            EntityList = EntityList.Where(p => p.CompanySuffix.ToLower().Contains(namePart.ToLower()));
            return this;
        }
        public IShopFilterBuilder ApplyCompanyPhonePrefix(int prefix)
        {
            EntityList = EntityList.Where(p => p.PhoneNumber.Prefix.Contains(prefix.ToString()));
            return this;
        }

        public IShopFilterBuilder ApplyOrderByNameAsc(string column)
        {
            switch (column)
            {
                case "name":
                    EntityList = EntityList.OrderBy(p => p.Name);
                    break;
                case "suffix":
                    EntityList = EntityList.OrderBy(p => p.CompanySuffix);
                    break;
                //...
            }
            return this;
        }
        public IShopFilterBuilder ApplyOrderByNameDesc()
        {
            EntityList = EntityList.OrderByDescending(p => p.Name);
            return this;
        }


        public IQueryable<Shop> Build()
        {
            return EntityList;
        }
    }
}
