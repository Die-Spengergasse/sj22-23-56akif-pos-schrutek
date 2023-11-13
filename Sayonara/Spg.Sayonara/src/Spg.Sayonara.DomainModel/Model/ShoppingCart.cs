using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public ShoppingCardStatus ShoppingCardStatus { get; set; }
        //public List<ShoppingCartProduct> ShoppingCartProducts { get; set; } = new();
    }
}
