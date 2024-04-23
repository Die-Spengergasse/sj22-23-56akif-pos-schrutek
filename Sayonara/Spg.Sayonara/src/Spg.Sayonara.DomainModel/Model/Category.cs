using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Model
{
    public class Category
    {
        // nur für EF Core
        private Category()
        { }
        public Category(string name)
        {
            Name = name;
        }

        public Category(string name, Shop shopNavigation)
            : this(name)
        {
            ShopNavigation = shopNavigation;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShopName { get; set; }
        public Shop ShopNavigation { get; set; } = default!; // Navigational Property

        private List<Product> _products = new();
        public IReadOnlyList<Product> Products => _products;

        public Category AddProduct(Product newProduct)
        {
            if (newProduct is not null)
            {
                // TODO: Checks, Properties setzen, ...
                newProduct.CategoryNavigation = this;
                _products.Add(newProduct);
            }
            return this;
        }

        public Category AddProducts(IEnumerable<Product> categories)
        {
            var result = categories
                .Where(p => p is not null)
                .Distinct()
                .Select(p => new Product(p.Guid, p.Name, p.Description, p.ExpiryDate, this));
            _products.AddRange(result);
            return this;
        }
    }
}
