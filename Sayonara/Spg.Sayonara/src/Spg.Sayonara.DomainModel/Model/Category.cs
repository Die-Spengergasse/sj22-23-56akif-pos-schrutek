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
        public int ShopId { get; set; }
        public Shop ShopNavigation { get; set; } = default!; // Navigational Property
    }
}
