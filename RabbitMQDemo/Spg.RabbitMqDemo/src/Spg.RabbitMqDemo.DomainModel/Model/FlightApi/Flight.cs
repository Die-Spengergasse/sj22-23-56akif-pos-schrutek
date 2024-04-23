using Spg.RabbitMqDemo.DomainModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.DomainModel.Model.FlightApi
{
    public class Flight
    {
        protected Flight()
        { }
        public Flight(
            string identifier,
            DestinationLookup fromDestinationNavigation, 
            DestinationLookup toDestinationNavigation, 
            DateTime departure,
            DateTime checkIn)
        {
            Identifier = identifier;
            FromDestinationNavigation = fromDestinationNavigation;
            ToDestinationNavigation = toDestinationNavigation;
            Departure = departure;
            CheckIn = checkIn;
        }

        public int Id { get; private set; }
        public string Identifier { get; set; }
        public DestinationLookup FromDestinationNavigation { get; set; } = default!;
        public DestinationLookup ToDestinationNavigation { get; set; } = default!;
        public DateTime Departure { get; set; }
        public DateTime CheckIn { get; set; }

        public PostFlightCreationDto ToDto()
        {
            return new PostFlightCreationDto(
                Identifier,
                FromDestinationNavigation.ToDto(),
                ToDestinationNavigation.ToDto(),
                Departure);
        }
    }
}
