using Spg.Sayonara.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.UseCases.Shop.Queries
{
    public interface IShopFilter
    {
        IShopFilterBuilder Compile(IShopFilterBuilder builder);
    }
}
