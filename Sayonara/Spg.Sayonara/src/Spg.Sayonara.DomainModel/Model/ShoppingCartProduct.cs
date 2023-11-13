using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Model
{
    public class ShoppingCartProduct
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public Product Product { get; set; } = default!;
    }
}
