using Spg.RabbitMqDemo.DomainModel.Interfaces;
using Spg.RabbitMqDemo.DomainModel.Model.FlightApi;
using Spg.RabbitMqDemo.Infrastructure.FlightApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.Repository.FlightApi
{
    public class DestinationLookupRepository : IDestinationLookupRepository
    {
        private readonly FlightDatabase _db;

        public DestinationLookupRepository(FlightDatabase db)
        {
            _db = db;
        }

        public DestinationLookup GetDestinationByCity(string cityName)
        {
            return _db.DestinationLookup.SingleOrDefault(d => d.CityName.ToLower() == cityName.ToLower())
                ?? throw new ArgumentException("Not found!");
        }
    }
}
