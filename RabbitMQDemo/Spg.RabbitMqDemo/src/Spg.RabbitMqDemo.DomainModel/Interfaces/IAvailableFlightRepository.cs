using Spg.RabbitMqDemo.DomainModel.Model.BookingApi;

namespace Spg.RabbitMqDemo.DomainModel.Interfaces
{
    public interface IAvailableFlightRepository
    {
        IQueryable<AvailableFlight> GetAll();

        void Create(AvailableFlight entity);
    }
}
