using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.DomainModel.Model.BookingApi
{
    public class AvailableFlight
    {
        protected AvailableFlight()
        { }
        public AvailableFlight(
            string identifier,
            string flightNumber, 
            string fromDestination, 
            string toDestination, 
            DateTime departure, 
            decimal basePrice, 
            string planeType)
        {
            Identifier = identifier;
            FlightNumber = flightNumber;
            FromDestination = fromDestination;
            ToDestination = toDestination;
            Departure = departure;
            BasePrice = basePrice;
            PlaneType = planeType;
        }

        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public string FlightNumber { get; set; } = string.Empty;
        public string FromDestination { get; set; } = string.Empty;
        public string ToDestination { get; set; } = string.Empty;
        public DateTime Departure { get; set; }
        public decimal BasePrice { get; set; }
        public string PlaneType { get; set; } = string.Empty;
    }
}
