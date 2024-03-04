using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Repository.Builder
{
    public class ProductFilterBuilderMock : IProductFilterBuilder
    {
        public IProductFilterBuilder ApplyNameContainsFilter(string namePart)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Build()
        {
            throw new NotImplementedException();
        }
    }
}
