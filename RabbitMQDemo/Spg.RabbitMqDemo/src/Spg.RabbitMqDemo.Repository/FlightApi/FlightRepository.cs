using Microsoft.EntityFrameworkCore;
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
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightDatabase _db;

        public FlightRepository(FlightDatabase db)
        {
            _db = db;
        }

        public void Create(Flight flight)
        {
            _db.Add(flight);
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ex) 
            {
                throw new InvalidOperationException("Error...", ex);
            }
        }
    }
}
