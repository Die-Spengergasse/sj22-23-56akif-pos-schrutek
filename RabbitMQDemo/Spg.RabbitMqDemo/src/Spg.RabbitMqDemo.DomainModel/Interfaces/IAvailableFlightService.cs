using Spg.RabbitMqDemo.DomainModel.Model.BookingApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.DomainModel.Interfaces
{
    public interface IAvailableFlightService
    {
        IQueryable<AvailableFlight> GetAll();
        void PersistReceivedFlight(IFlightCreation flightData);
    }
}
