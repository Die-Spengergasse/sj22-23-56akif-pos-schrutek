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
    public class CategoryRepository : IReadOnlyCategoryRepository
    {
        private readonly SayonaraContext _context;

        public CategoryRepository(SayonaraContext context)
        {
            _context = context;
        }

        public Category? GetCategoryOrDefault(int id)
        {
            return _context.Categories.Find(id);
        }

        public Category? GetCategory(int id)
        {
            return _context
                .Shops
                .Select(s => s.Categories.SingleOrDefault(c => c.Id == id && c != null))
                .SingleOrDefault();
        }
    }
}
