using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Interfaces
{
    public interface IEntityFilterBuilder<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> EntityList { get; set; }
        IQueryable<TEntity> Build();
    }
}
