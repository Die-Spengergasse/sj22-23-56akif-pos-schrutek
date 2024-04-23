using Spg.RabbitMqDemo.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.DomainModel.Dtos
{
    public record PostFlightCreationDto(
        string Identifier,
        DestinationDto FromDestination,
        DestinationDto ToDestination,
        DateTime Departure)
        : IFlightCreation;
}
