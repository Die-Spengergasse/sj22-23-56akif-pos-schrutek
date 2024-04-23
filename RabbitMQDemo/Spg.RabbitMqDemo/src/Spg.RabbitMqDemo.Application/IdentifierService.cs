using Spg.RabbitMqDemo.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.Application
{
    public class IdentifierService : IIdentifierService
    {
        // TODO: Erstzen durch Logik, die eine alphanumerische
        // Folge inkl. Checksumme generiert.
        public string GetIdentifier() 
            => Guid.NewGuid().ToString();
    }
}
