using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using Spg.Sayonara.DomainModel.Exceptions;
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
    public class ProductRepository : IReadOnlyProductRepository, IWritableProductRepository
    {
        private readonly SayonaraContext _context;

        public IProductFilterBuilder FilterBuilder { get; set; }

        public ProductRepository(SayonaraContext context)
        {
            _context = context;

            FilterBuilder = new ProductFilterBuilder(_context.Products);
        }

        public IProductUpdateBuilder UpdateBuilder(Product entity)
        {
            return new ProductUpdateBuilder(_context, entity);
        }

        public int Create(Product entity)
        {
            // TODO: ExceptionHandling
            _context.Products.Add(entity);
            return _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product? GetByCategoryOrDefault(int categoryId, string name) 
        {
            return _context
                .Categories?
                .SingleOrDefault(c => c.Id == categoryId)?
                .Products
                .SingleOrDefault(p => p.Name == name);
        }

        public bool ExistsByCategoryOrDefault(int categoryId, string name)
        {
            return _context
                .Categories?
                .SingleOrDefault(c => c.Id == categoryId)?
                .Products
                .Any(p => p.Name == name)
                    ?? false;
        }

        //TODO: Find(id), Find(guid), Find(Name), ...
    }
}
