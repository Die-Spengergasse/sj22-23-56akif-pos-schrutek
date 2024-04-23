using Spg.RabbitMqDemo.DomainModel.Dtos;
using Spg.RabbitMqDemo.DomainModel.Model.FlightApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.DomainModel.Interfaces
{
    public interface IRabbitMqRepository
    {
        void PostFlightCreation(Flight entity);
    }
}
