using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Repository
{
    public class ProductRepository
    {
        private readonly SayonaraContext _db;

        public ProductRepository(SayonaraContext db, int x)
        {
            _db = db;
            FilterBuilder = new ProductFilterBuilder(_db.Products);
        }

        public IProductFilterBuilder FilterBuilder { get; set; }

        // Write-OP
        public int Create(Product entity)
        {
            // TODO: ExceptionHandling
            _db.Products.Add(entity);
            return _db.SaveChanges();
        }

        // TODO: Delete(key)

        // TODO: Update (Builder-Pattern)

        // Read-OP
        // TODO: GetOne(key)

        // TODO: GetAll()

        // TODO: Filterung (Builder-Pattern)
    }
}
