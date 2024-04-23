using Microsoft.EntityFrameworkCore;
using Spg.RabbitMqDemo.DomainModel.Interfaces;
using Spg.RabbitMqDemo.DomainModel.Model.BookingApi;
using Spg.RabbitMqDemo.DomainModel.Model.FlightApi;
using Spg.RabbitMqDemo.Infrastructure.BookingApi;

namespace Spg.RabbitMqDemo.Repository.BookingApi
{
    public class AvailableFlightRepository : IAvailableFlightRepository
    {
        private readonly BookingDatabase _db;

        public AvailableFlightRepository(BookingDatabase db)
        {
            _db = db;
        }

        public IQueryable<AvailableFlight> GetAll()
        {
            return _db.AvailableFlights;
        }

        public void Create(AvailableFlight entity)
        {
            _db.Add(entity);
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
