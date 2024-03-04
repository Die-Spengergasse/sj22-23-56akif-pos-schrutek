using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Interfaces
{
    public interface IWritableProductService
    {
        ProductDto Create(CreateProductCommand command);
    }
}
