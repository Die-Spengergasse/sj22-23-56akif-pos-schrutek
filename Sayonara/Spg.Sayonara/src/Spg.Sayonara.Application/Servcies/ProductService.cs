using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.Servcies
{
    public class ProductService
    {
        private readonly SayonaraContext _db;
        private readonly IDateTimeService _dateTimeService;

        public ProductService(SayonaraContext db, IDateTimeService dateTimeService)
        {
            //_db = new SayonaraContext();
            _dateTimeService = dateTimeService;
            _db = db;
        }

        public void Create(string name, string description, DateTime expiryDate)
        {
            // Init (Arrange)
            Product newProduct = new Product(name, description, expiryDate, null);

            // Validation
            // Bedingungen:
            // * Ablaufdatum muss 14 Tage in der Zukunft liegen
            // * User darf das tun
            // * ... 
            // THE FOLLOWING IST BAD-CODING!!!!!!!!!!!!!!
            //if (expiryDate >= _dateTimeService.Now.AddDays(14))
            //{
            //    // * Name muss eindeutig sein
            //    if (_db.Products.Any(p => p.Name != name))
            //    {
            //        // * [unknown] darf nicht als Beschreibung verewendet werden.
            //        if (description != "[unknown]")
            //        {
            //            // Act
            //            _db.Products.Add(newProduct);
            //            // Save
            //            // TODO: Exception Handling
            //            _db.SaveChanges();
            //        }
            //        else
            //        {
            //            throw new Exception();
            //        }
            //    }
            //    else 
            //    {
            //        throw new Exception();
            //    }
            //}
            //else
            //{
            //    throw new Exception();
            //}

            //// Act
            //_db.Products.Add(newProduct);
            //// Save
            //// TODO: Exception Handling
            //_db.SaveChanges();
        }
    }
}
