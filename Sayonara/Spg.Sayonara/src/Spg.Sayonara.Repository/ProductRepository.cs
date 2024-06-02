using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.DomainModel.Exceptions;
using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository.Builder;
using System;

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
            try
            {
                _context.Products.Add(entity);
                return _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw RepositoryCreateException.FromDbError(ex);
            }
            catch (DbUpdateException ex)
            {
                throw RepositoryCreateException.FromDbError(ex);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity? GetByGuid<TEntity>(Guid guid)
            where TEntity : class, IFindableByGuid
        {
            return _context
                .Set<TEntity>()
                .SingleOrDefault(p => p.Guid == guid);
        }

        public TEntity? GetByEMail<TEntity>(string eMail)
            where TEntity : class, IFindableByEMail
        {
            return _context
                .Set<TEntity>()
                .SingleOrDefault(p => p.EMail.Address == eMail);
        }

        public TEntity? GetByLastName<TEntity>(string lastName)
            where TEntity : class, IFindableByLastName
        {
            return _context
                .Set<TEntity>()
                .SingleOrDefault(p => p.LastName == lastName);
    }

        public Product? GetByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
    }
