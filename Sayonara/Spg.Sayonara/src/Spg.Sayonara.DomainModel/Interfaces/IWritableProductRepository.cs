using Spg.Sayonara.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Interfaces
{
    public interface IWritableProductRepository
    {
        IProductUpdateBuilder UpdateBuilder(Product entity);

        int Create(Product entity);
        void Delete(int id);
    }
}
