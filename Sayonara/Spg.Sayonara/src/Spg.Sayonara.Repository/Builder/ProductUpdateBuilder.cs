using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.DomainModel.Exceptions;
using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;

namespace Spg.Sayonara.Repository.Builder
{
    public class ProductUpdateBuilder : IProductUpdateBuilder
    {
        private readonly SayonaraContext _context;
        private readonly Product _entity;

        public ProductUpdateBuilder(SayonaraContext context, Product entity)
        {
            _entity = entity;
            _context = context;
        }

        public IProductUpdateBuilder WithName(string name)
        {
            _entity.Name = name;
            return this;
        }
        public IProductUpdateBuilder WithDescription(string description)
        {
            _entity.Description = description;
            return this;
        }
        public IProductUpdateBuilder WithExpiryDate(DateTime expiryDate)
        {
            _entity.ExpiryDate = expiryDate;
            return this;
        }

        public int Save()
        {
            _context.Update(_entity);
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryCreateException("Produkt konnte nicht angelegt werden!", ex);
            }
        }
    }
}
