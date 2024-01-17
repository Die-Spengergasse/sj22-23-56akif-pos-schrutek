using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;

namespace Spg.Sayonara.Repository.Builder
{
    public class ProductFilterBuilder : IProductFilterBuilder
    {
        private IQueryable<Product> Products { get; set; }

        public ProductFilterBuilder(IQueryable<Product> products)
        {
            Products = products;
        }

        public IProductFilterBuilder ApplyNameContainsFilter(string namePart)
        {
            Products = Products.Where(p => p.Name.ToLower().Contains(namePart.ToLower()));
            return this;
        }

        // TODO: Weiter Methoden (Filterung / Sortierung)

        public void Build()
        {
            // TODO: void durch richtigen datentyp ersetzen und prodkt zurückgeben.
        }
    }
}
