using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;

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
