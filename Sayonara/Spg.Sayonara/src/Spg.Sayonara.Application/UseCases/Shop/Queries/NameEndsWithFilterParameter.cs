using Spg.Sayonara.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.UseCases.Shop.Queries
{
    public class NameEndsWithFilterParameter : IShopFilter
    {
        private readonly string _filterParameter;

        public NameEndsWithFilterParameter(string filterParameter)
        {
            _filterParameter = filterParameter;
        }
        public IShopFilterBuilder Compile(IShopFilterBuilder builder)
        {
            // TODO: Saubere Logik + Checks
            if (!string.IsNullOrEmpty(_filterParameter))
            {
                string[] parts = _filterParameter.Split(" ");
                if (parts.Count() == 3)
                {
                    if ((!string.IsNullOrEmpty(parts[2])
                        && parts[0].ToLower().Trim() == "name"
                        && parts[1].ToLower().Trim() == "ew"))
                    {
                        builder.ApplyNameEndWithFilter(parts[2]);
                    }
                }
            }
            return builder;
        }
    }
}
