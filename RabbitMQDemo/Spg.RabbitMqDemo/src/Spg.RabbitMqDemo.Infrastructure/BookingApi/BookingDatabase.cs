using Microsoft.EntityFrameworkCore;
using Spg.RabbitMqDemo.DomainModel.Model.BookingApi;
using Spg.RabbitMqDemo.DomainModel.Model.FlightApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.Infrastructure.BookingApi
{
    public class BookingDatabase : DbContext
    {
        public DbSet<AvailableFlight> AvailableFlights => Set<AvailableFlight>();

        public BookingDatabase(DbContextOptions options)
            : base(options)
        { }
    }
}
