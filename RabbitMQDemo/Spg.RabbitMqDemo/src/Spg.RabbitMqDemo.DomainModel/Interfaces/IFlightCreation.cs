using Spg.RabbitMqDemo.DomainModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.DomainModel.Interfaces
{
    public interface IFlightCreation
    {
        public string Identifier { get; }
        public DestinationDto FromDestination { get; }
        public DestinationDto ToDestination { get; }
        public DateTime Departure { get; }
    }
}
