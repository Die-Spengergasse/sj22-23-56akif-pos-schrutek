using Spg.RabbitMqDemo.DomainModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.DomainModel.Model.FlightApi
{
    public class DestinationLookup
    {
        protected DestinationLookup()
        { }
        public DestinationLookup(string cityName, string continent)
        {
            CityName = cityName;
            Continent = continent;
        }

        public string CityName { get; set; } = string.Empty;
        public string Continent { get; set; } = string.Empty;

        //private List<Flight> _flights { get; set; } = new();
        //public IReadOnlyList<Flight> Flights => _flights;

        public DestinationDto ToDto() 
        {
            return new DestinationDto(CityName, Continent);
        }
    }
}
