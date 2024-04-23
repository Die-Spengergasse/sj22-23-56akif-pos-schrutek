using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.DomainModel.Dtos
{
    public record DestinationDto(
        string CityName,
        string Continent);
}
