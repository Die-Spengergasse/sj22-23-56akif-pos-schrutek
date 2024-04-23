using MassTransit;
using Microsoft.EntityFrameworkCore;
using Spg.RabbitMqDemo.DomainModel.Interfaces;
using Spg.RabbitMqDemo.DomainModel.Model.FlightApi;

namespace Spg.RabbitMqDemo.Repository
{
    public class RabbitMqRepository : IRabbitMqRepository
    {
        private readonly IPublishEndpoint _publishEndPoint;

        public RabbitMqRepository(IPublishEndpoint publishEndPoint)
        {
            _publishEndPoint = publishEndPoint;
        }

        public void PostFlightCreation(Flight entity)
        {
            try
            {
                _publishEndPoint.Publish(entity.ToDto());
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Error...", ex);
            }
        }
    }
}
