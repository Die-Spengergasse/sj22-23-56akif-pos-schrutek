using Spg.Sayonara.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Interfaces
{
    public interface IShopFilterBuilder
    {
        IQueryable<Shop> EntityList { get; set; }

        IShopFilterBuilder ApplyNameContainsFilter(string namePart);
        IShopFilterBuilder ApplyNameStartsWithFilter(string namePart);
        IShopFilterBuilder ApplyNameEndWithFilter(string namePart);
        IShopFilterBuilder ApplyCompanySuffixContainsFilter(string namePart);
        IShopFilterBuilder ApplyCompanyPhonePrefix(int prefix);
        IShopFilterBuilder ApplyOrderByNameAsc(string column);



        IQueryable<Shop> Build();
    }
}
