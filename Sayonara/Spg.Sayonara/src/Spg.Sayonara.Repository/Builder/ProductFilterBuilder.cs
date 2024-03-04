using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;

namespace Spg.Sayonara.Repository.Builder
{
    public class ProductFilterBuilder : IProductFilterBuilder
    {
        public IQueryable<Product> EntityList { get; set; }

        public ProductFilterBuilder(IQueryable<Product> products)
        {
            EntityList = products;
        }

        public IProductFilterBuilder ApplyNameContainsFilter(string namePart)
        {
            EntityList = EntityList.Where(p => p.Name.ToLower().Contains(namePart.ToLower()));
            return this;
        }

        // TODO: Weiter Methoden (Filterung / Sortierung)

        public IQueryable<Product> Build()
        {
            return EntityList;
        }
    }
}
