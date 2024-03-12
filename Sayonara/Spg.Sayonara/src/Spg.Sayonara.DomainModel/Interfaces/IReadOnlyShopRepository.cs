using Spg.Sayonara.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Interfaces
{
    public interface IReadOnlyShopRepository
    {
        IShopFilterBuilder FilterBuilder { get; set; }
        IQueryable<Shop> GetAll();
        Shop GetSingle(int id);
    }
}
