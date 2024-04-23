using Microsoft.EntityFrameworkCore;
using Spg.RabbitMqDemo.DomainModel.Model.FlightApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.RabbitMqDemo.Infrastructure.FlightApi
{
    public class FlightDatabase : DbContext
    {
        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<DestinationLookup> DestinationLookup => Set<DestinationLookup>();

        public FlightDatabase(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DestinationLookup>().HasKey(d => d.CityName);

            builder.Entity<DestinationLookup>().HasData(
                new List<DestinationLookup>()
                {
                    new DestinationLookup("Tokio", "Asien"),
                    new DestinationLookup("New York", "Nordamerika"),
                    new DestinationLookup("London", "Europa"),
                    new DestinationLookup("Sydney", "Australien"),
                    new DestinationLookup("Kairo", "Afrika"),
                    new DestinationLookup("Rom", "Europa"),
                    new DestinationLookup("Rio de Janeiro", "Südamerika"),
                    new DestinationLookup("Peking", "Asien"),
                    new DestinationLookup("Los Angeles", "Nordamerika"),
                    new DestinationLookup("Paris", "Europa"),
                    new DestinationLookup("Singapur", "Asien"),
                    new DestinationLookup("Toronto", "Nordamerika"),
                    new DestinationLookup("Berlin", "Europa"),
                    new DestinationLookup("Istanbul", "Europa"),
                    new DestinationLookup("Kapstadt", "Afrika"),
                    new DestinationLookup("Moskau", "Europa"),
                    new DestinationLookup("Mumbai", "Asien"),
                    new DestinationLookup("São Paulo", "Südamerika"),
                    new DestinationLookup("Dubai", "Asien"),
                    new DestinationLookup("New Delhi", "Asien"),
                    new DestinationLookup("Seoul", "Asien"),
                    new DestinationLookup("Mexiko-Stadt", "Nordamerika"),
                    new DestinationLookup("Madrid", "Europa"),
                    new DestinationLookup("Jakarta", "Asien"),
                    new DestinationLookup("Kuala Lumpur", "Asien"),
                    new DestinationLookup("Bangkok", "Asien"),
                    new DestinationLookup("Wien", "Europa"),
                    new DestinationLookup("Amsterdam", "Europa"),
                    new DestinationLookup("Prag", "Europa"),
                    new DestinationLookup("Honolulu", "Ozeanien"),
                    new DestinationLookup("Buenos Aires", "Südamerika"),
                    new DestinationLookup("Stockholm", "Europa"),
                    new DestinationLookup("Helsinki", "Europa"),
                    new DestinationLookup("Dublin", "Europa"),
                    new DestinationLookup("Zürich", "Europa"),
                    new DestinationLookup("Oslo", "Europa"),
                    new DestinationLookup("San Francisco", "Nordamerika"),
                    new DestinationLookup("Las Vegas", "Nordamerika"),
                    new DestinationLookup("Denver", "Nordamerika"),
                    new DestinationLookup("Boston", "Nordamerika"),
                    new DestinationLookup("Miami", "Nordamerika"),
                    new DestinationLookup("Seattle", "Nordamerika"),
                    new DestinationLookup("Chicago", "Nordamerika"),
                    new DestinationLookup("Atlanta", "Nordamerika"),
                    new DestinationLookup("Dallas", "Nordamerika"),
                    new DestinationLookup("Houston", "Nordamerika"),
                    new DestinationLookup("Philadelphia", "Nordamerika"),
                });
        }
    }
}
